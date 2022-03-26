// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace zFramework.Media
{
    /// <summary>
    /// Interface for a storage of a single video frame.
    /// </summary>
    public interface IVideoFrameStorage
    {
        /// <summary>
        /// Frame width, in pixels.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Frame height, in pixels.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Raw storage buffer
        /// </summary>
        byte[] Buffer { get; set; }
        /// <summary>
        /// storage Y panel buffer
        /// </summary>
        byte[] Buffer_Y { get; set; }
        /// <summary>
        /// storage Y panel buffer
        /// </summary>
        byte[] Buffer_U { get; set; }
        /// <summary>
        /// storage Y panel buffer
        /// </summary>
        byte[] Buffer_V { get; set; }
    }

    /// <summary>
    /// Storage for a video frame encoded in I420  format.
    /// </summary>
    public class I420AVideoFrameStorage : IVideoFrameStorage
    {
        /// <summary>
        /// Frame width, in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Frame height, in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Raw byte buffer containing the frame data.
        /// </summary>

        public byte[] Buffer { get; set; }
        public byte[] Buffer_Y { get; set; }
        public byte[] Buffer_U { get; set; }
        public byte[] Buffer_V { get; set; }

        internal long GetSize()
        {
            var size = 0L;
            if (null != Buffer)
            {
                size = Buffer.LongLength;
            }
            else if (null != Buffer_Y && null != Buffer_U && null != Buffer_V)
            {
                size = Buffer_Y.LongLength +
                              Buffer_U.LongLength +
                              Buffer_V.LongLength;
            }
            return size;
        }
    }

    /// <summary>
    /// Interface for a queue of video frames.
    /// </summary>
    public interface IVideoFrameQueue
    {
        /// <summary>
        /// Get the number of frames enqueued per seconds.
        /// This is generally an average statistics representing how fast a video source
        /// produces some video frames.
        /// </summary>
        float QueuedFramesPerSecond { get; }

        /// <summary>
        /// Get the number of frames enqueued per seconds.
        /// This is generally an average statistics representing how fast a video sink
        /// consumes some video frames, typically to render them.
        /// </summary>
        float DequeuedFramesPerSecond { get; }

        /// <summary>
        /// Get the number of frames dropped per seconds.
        /// This is generally an average statistics representing how many frames were
        /// enqueued by a video source but not dequeued fast enough by a video sink,
        /// meaning the video sink renders at a slower framerate than the source can produce.
        /// </summary>
        float DroppedFramesPerSecond { get; }
    }

    /// <summary>
    /// Small queue of video frames received from a source and pending delivery to a sink.
    /// Used as temporary buffer between the WebRTC callback (push model) and the video
    /// player rendering (pull model). This also handles dropping frames when the source
    /// is faster than the sink, by limiting the maximum queue length.
    /// </summary>
    /// <typeparam name="T">The type of video frame storage</typeparam>
    public class VideoFrameQueue<T> : IVideoFrameQueue where T : class, IVideoFrameStorage, new()
    {
        /// <inheritdoc/>
        public float QueuedFramesPerSecond
        {
            get
            {
                var value = 1000f / _queuedFrameTimeAverage.Average;
                if (float.IsInfinity(value))
                {
                    value = 0;
                }
                return value;
            }
        }

        /// <inheritdoc/>
        public float DequeuedFramesPerSecond
        {
            get
            {
                var value = 1000f / _dequeuedFrameTimeAverage.Average;
                if (float.IsInfinity(value))
                {
                    value = 0;
                }
                return value;
            }
        }

        /// <inheritdoc/>
        public float DroppedFramesPerSecond
        {
            get
            {
                var value = 1000f / _droppedFrameTimeAverage.Average;
                if (float.IsInfinity(value))
                {
                    value = 0;
                }
                return value;
            }
        }
        /// <summary>
        /// Queue of frames pending delivery to sink.
        /// </summary>
        private ConcurrentQueue<T> _frameQueue = new ConcurrentQueue<T>();

        /// <summary>
        /// Pool of unused frames available for reuse, to avoid memory allocations.
        /// </summary>
        private ConcurrentStack<T> _unusedFramePool = new ConcurrentStack<T>();

        /// <summary>
        /// Maximum queue length in number of frames.
        /// </summary>
        private int _maxQueueLength = 3;

        #region Statistics

        /// <summary>
        /// Shared clock for all frame statistics.
        /// </summary>
        private Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Time in milliseconds since last frame was enqueued, as reported by <see cref="_stopwatch"/>.
        /// </summary>
        private double _lastQueuedTimeMs = 0f;

        /// <summary>
        /// Time in milliseconds since last frame was dequeued, as reported by <see cref="_stopwatch"/>.
        /// </summary>
        private double _lastDequeuedTimeMs = 0f;

        /// <summary>
        /// Time in milliseconds since last frame was dropped, as reported by <see cref="_stopwatch"/>.
        /// </summary>
        private double _lastDroppedTimeMs = 0f;

        /// <summary>
        /// Moving average of the queued frame time, in frames per second.
        /// </summary>
        private DynamicAverage _queuedFrameTimeAverage = new DynamicAverage(30);

        /// <summary>
        /// Moving average of the dequeued frame time, in frames per second.
        /// </summary>
        private DynamicAverage _dequeuedFrameTimeAverage = new DynamicAverage(30);

        /// <summary>
        /// Moving average of the dropped frame time, in frames per second.
        /// </summary>
        private DynamicAverage _droppedFrameTimeAverage = new DynamicAverage(30);

        #endregion


        /// <summary>
        /// Create a new queue with a maximum frame length.
        /// </summary>
        /// <param name="maxQueueLength">Maxmimum number of frames to enqueue before starting to drop incoming frames</param>
        public VideoFrameQueue(int maxQueueLength)
        {
            _maxQueueLength = maxQueueLength;
            _stopwatch.Start();
        }

        /// <summary>
        /// Clear the queue and drop all frames currently pending.
        /// </summary>
        public void Clear()
        {
            _lastQueuedTimeMs = 0f;
            _lastDequeuedTimeMs = 0f;
            _lastDroppedTimeMs = 0f;
            _queuedFrameTimeAverage.Clear();
            _dequeuedFrameTimeAverage.Clear();
            _droppedFrameTimeAverage.Clear();
            while (_frameQueue.TryDequeue(out T _)) { }
            _unusedFramePool.Clear();
            _stopwatch.Restart();
        }

        public bool CanEnqueue => QueryQueueState();

        private bool QueryQueueState()
        {
            bool state = true;
            if (_frameQueue.Count >= _maxQueueLength)
            {
                state = false;
                double curTime = _stopwatch.Elapsed.TotalMilliseconds;

                //如果这一帧要丢弃，那也得被统计到 推流总帧率里面
                //不要写 if 语句外，否则不丢弃帧的情况下会统计两次
                float queuedDt = (float)(curTime - _lastQueuedTimeMs);
                _queuedFrameTimeAverage.Push(queuedDt);
                _lastQueuedTimeMs = curTime;

                // 数据发生丢弃，统计丢弃帧率
                float droppedDt = (float)(curTime - _lastDroppedTimeMs);
                _droppedFrameTimeAverage.Push(droppedDt);
                _lastDroppedTimeMs = curTime;
            }
            return state;
        }


        /// <summary>
        /// Enqueue a new video frame encoded in I420 format.
        /// If the internal queue reached its maximum capacity,drop the current 
        /// </summary>
        /// <param name="frame">The video frame to enqueue</param>
        /// <remarks>This should only be used if the queue has storage for a compatible video frame encoding.</remarks>
        public void Enqueue(I420VideoFrame frame)
        {
            double curTime = _stopwatch.Elapsed.TotalMilliseconds;

            // Always update queued time, which refers to calling Enqueue(), even
            // if the queue is full and the frame is dropped.
            float queuedDt = (float)(curTime - _lastQueuedTimeMs);
            _queuedFrameTimeAverage.Push(queuedDt);
            _lastQueuedTimeMs = curTime;

            // Try to get some storage for that new frame
            if (!_unusedFramePool.TryPop(out T storage))
            {
                storage = new T();
            }
            // Copy the new frame to its storage
            frame.ApplyTo(storage);
            // Enqueue for later delivery
            _frameQueue.Enqueue(storage);
        }


        /// <summary>
        /// Try to dequeue a video frame, usually to be consumed by a video sink (video player).
        /// </summary>
        /// <param name="frame">On success, returns the dequeued frame.</param>
        /// <returns>Return <c>true</c> on success or <c>false</c> if the queue is empty.</returns>
        public bool TryDequeue(out T frame)
        {
            if (_frameQueue.TryDequeue(out frame))
            {
                // Only track dequeued time if actually dequeued. Otherwise this will generate
                // duplicate timings in the buffer (twice or more per frame) and will result in
                // completely unreliable averages.
                double curTime = _stopwatch.Elapsed.TotalMilliseconds;
                float dequeuedDt = (float)(curTime - _lastDequeuedTimeMs);
                _lastDequeuedTimeMs = curTime;
                _dequeuedFrameTimeAverage.Push(dequeuedDt);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Recycle a frame storage, putting it back into the internal pool for later reuse.
        /// This prevents deallocation and reallocation of a frame, and decreases pressure on
        /// the garbage collector.
        /// </summary>
        /// <param name="frame">The unused frame storage to recycle for a later new frame</param>
        public void RecycleStorage(T frame)
        {
            _unusedFramePool.Push(frame);
        }

        /// <summary>
        /// Track statistics for a late frame, which short-circuits the queue and is delivered
        /// as soon as it is received.
        /// </summary>
        public void TrackLateFrame()
        {
            double curTime = _stopwatch.Elapsed.TotalMilliseconds;

            float queuedDt = (float)(curTime - _lastQueuedTimeMs);
            _lastQueuedTimeMs = curTime;
            _queuedFrameTimeAverage.Push(queuedDt);

            float dequeuedDt = (float)(curTime - _lastDequeuedTimeMs);
            _lastDequeuedTimeMs = curTime;
            _dequeuedFrameTimeAverage.Push(dequeuedDt);
            _droppedFrameTimeAverage.Push((float)(curTime - _lastDroppedTimeMs));
        }

    }
}