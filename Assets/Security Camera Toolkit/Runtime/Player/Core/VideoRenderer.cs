// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace zFramework.Media
{
    /// <summary>
    /// 视频渲染器：将 YUV 格式画面转换为 RGB888 并合并成监控画面
    /// </summary>
    [RequireComponent(typeof(RawImage))]
    public class VideoRenderer : MonoBehaviour
    {
        #region Show In Inspector
        [Header("开启统计："), Tooltip(aboutstatistics)]
        public bool enableStatistics = true;
        [Header("绘制帧率："), Range(15, 60), Tooltip(aboutframrate)]
        public int framerate = 25;
        [Header("帧队列最大容量："), Range(2, 5), Tooltip(aboutQueueSize)]
        public int maxFrameQueueSize = 3;
        [Header("帧数统计事件"), Tooltip(aboutevent)]
        public VideoRendererEvent OnStatisticsReported = new VideoRendererEvent();
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake() => monitor = GetComponent<RawImage>();
        //将监控画面设置为空白，避免用户以为画面卡死
        protected void OnDisable() => CreateEmptyVideoTextures();
        void Start()
        {
            monitor.material = new Material(monitor.material);
            videoMaterial = monitor.materialForRendering;
            CreateEmptyVideoTextures();
        }
        void Update() => TryProcessI420VideoFrame();


        #endregion

        #region Renderer Behaviours
        /// <summary>
        /// 停止渲染
        /// </summary>
        public void StopRendering(IVideoSource source)
        {
            source.OnVideoFrameReady -= I420AVideoFrameReady;
            source.OnInterruptedSignal -= OnInterruptedSignal;
            videoFrameQueue?.Clear();
            CreateEmptyVideoTextures();
        }

        public void PauseRendering() => videoFrameQueue?.Clear();


        /// <summary>
        /// 开始处理从视频源推送过来的数据
        /// </summary>
        public void StartRendering(IVideoSource source)
        {
            videoFrameQueue = new VideoFrameQueue<I420AVideoFrameStorage>(maxFrameQueueSize);
            source.OnVideoFrameReady += I420AVideoFrameReady;
            source.OnInterruptedSignal += OnInterruptedSignal;
        }

        #endregion

        #region Assistant Fuction

        private bool OnInterruptedSignal() =>!videoFrameQueue.CanEnqueue;
        private void CreateEmptyVideoTextures()
        {
            _textureY = _textureU = _textureV = null;
            if (videoMaterial)
            {
                videoMaterial.SetTexture(attr_y, _textureY);
                videoMaterial.SetTexture(attr_u, _textureU);
                videoMaterial.SetTexture(attr_v, _textureV);
            }
        }
        protected void I420AVideoFrameReady(I420VideoFrame frame)
        {
            // 视频数据的采集是在非 Unity 主线程，为了渲染到 UI ，先进栈等待主线程处理
            videoFrameQueue.Enqueue(frame);
        }

        private void TryProcessI420VideoFrame()
        {
            // 计算取画面帧的间隔，想流畅就接近推流速率，比如推流 25 fps，你就设置25 左右
            // 反之，设小的话，推流时就会丢弃帧数据，显得不流畅，但是渲染减少，内存对拷减少，进而性能更好些
            if (preFrameRate != framerate)
            {
                preFrameRate = framerate;
                frameDuration = Mathf.Max(0f, 1f / Mathf.Max(15, framerate) - 0.003f);
            }

            if (videoFrameQueue != null)
            {
                var curTime = Time.time;
                if (curTime - lastUpdateTime >= frameDuration)
                {
                    DoProcess();
                    lastUpdateTime = curTime;
                }
                ReportProfilerStatistics();
            }

            void DoProcess()
            {
                if (videoFrameQueue.TryDequeue(out I420AVideoFrameStorage frame))
                {
                    int lumaWidth = (int)frame.Width;
                    int lumaHeight = (int)frame.Height;
                    if (_textureY == null || (_textureY.width != lumaWidth || _textureY.height != lumaHeight))
                    {
                        _textureY = new Texture2D(lumaWidth, lumaHeight, TextureFormat.Alpha8, mipChain: false);
                        videoMaterial.SetTexture(attr_y, _textureY);
                    }
                    int chromaWidth = lumaWidth / 2;
                    int chromaHeight = lumaHeight / 2;
                    if (_textureU == null || (_textureU.width != chromaWidth || _textureU.height != chromaHeight))
                    {
                        _textureU = new Texture2D(chromaWidth, chromaHeight, TextureFormat.Alpha8, mipChain: false);
                        videoMaterial.SetTexture(attr_u, _textureU);
                    }
                    if (_textureV == null || (_textureV.width != chromaWidth || _textureV.height != chromaHeight))
                    {
                        _textureV = new Texture2D(chromaWidth, chromaHeight, TextureFormat.Alpha8, mipChain: false);
                        videoMaterial.SetTexture(attr_v, _textureV);
                    }

                    using (var profileScope = loadTextureDataMarker.Auto())
                    {
                        _textureY.LoadRawTextureData(frame.Buffer_Y);
                        _textureU.LoadRawTextureData(frame.Buffer_U);
                        _textureV.LoadRawTextureData(frame.Buffer_V);
                    }

                    // Upload from system memory to GPU
                    using (var profileScope = uploadTextureToGpuMarker.Auto())
                    {
                        _textureY.Apply();
                        _textureU.Apply();
                        _textureV.Apply();
                    }

                    // Recycle the video frame packet for a later frame
                    videoFrameQueue.RecycleStorage(frame);
                }
            }
        }

        private void ReportProfilerStatistics()
        {
            if (enableStatistics)
            {
                // Share our stats values, if possible.
                using (var profileScope = displayStatsMarker.Auto())
                {
                    IVideoFrameQueue stats = (IVideoFrameQueue)videoFrameQueue;
                    var frameLoad = stats.QueuedFramesPerSecond.ToString("F2");
                    var frameRender = stats.DequeuedFramesPerSecond.ToString("F2");
                    var frameDrop = stats.DroppedFramesPerSecond.ToString("F2");
                    OnStatisticsReported.Invoke(frameLoad, frameRender, frameDrop);
                }
            }
        }

        #endregion

        #region Some Fields
        RawImage monitor;
        Material videoMaterial;
        /// <summary>
        /// 视频帧队列
        /// </summary>
        private VideoFrameQueue<I420AVideoFrameStorage> videoFrameQueue = null;
        private float frameDuration;
        private float lastUpdateTime;

        private ProfilerMarker displayStatsMarker = new ProfilerMarker("DisplayStats");
        private ProfilerMarker loadTextureDataMarker = new ProfilerMarker("LoadTextureData");
        private ProfilerMarker uploadTextureToGpuMarker = new ProfilerMarker("UploadTextureToGPU");

        /// <summary>
        /// YUV Shader 接受的三个通道的贴图
        /// </summary>
        private Texture2D _textureY, _textureU, _textureV; //RGB888
        /// <summary>
        /// YUV Shader 接受的三个通道的属性
        /// </summary>
        private string attr_y = "_YTexture", attr_u = "_UTexture", attr_v = "_VTexture";
        private int preFrameRate = 0;
        [Serializable]
        public class VideoRendererEvent : UnityEvent<string, string, string> { }
        #endregion
        #region Tooltips
        const string aboutstatistics = "开启后 OnStatisticsReported 事件才会进行分发，反之不会";
        const string aboutframrate = "为快速交换数据稍微设置大一些，目前设小会导致播放画面滞后，推荐值大于 SDK 推流帧率即可";
        const string aboutQueueSize = "一帧视频数据可观，减少队列容量，避免内存高涨";
        const string aboutevent = "返回值分别为加载 、渲染、丢弃帧数的平均值，对于监控来说，渲染15帧就已经很流畅了";
        #endregion
    }
}

