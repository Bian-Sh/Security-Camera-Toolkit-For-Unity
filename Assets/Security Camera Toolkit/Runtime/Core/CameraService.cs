// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    public class CameraService : IVideoSource
    {
        public SecurityCamera facade;
        public object loginHandle; //登录句柄，数据类型：int 、c#指针 
        public virtual bool HasLogin { get; }
        public virtual bool IsRealPlaying { get; }
        public bool Enabled => IsRealPlaying;

        //暂停
        protected bool isPause = false;
        object eventlocka = new object();
        object eventlockb = new object();
        protected bool isVideoRendererReady = false;
        protected bool isFrameBlockedSignalReady = false;
        /// <summary>
        /// 视频帧广播事件
        /// </summary>
        public event I420AVideoFrameDelegate OnVideoFrameReady
        {
            add
            {
                lock (eventlocka)
                {
                    frameReady += value;
                    isVideoRendererReady = true;
                }
            }
            remove
            {
                lock (eventlocka)
                {
                    frameReady -= value;
                    isVideoRendererReady = frameReady != null;
                }
            }
        }
        protected I420AVideoFrameDelegate frameReady;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event ProcessInterruptSignal OnInterruptedSignal
        {
            add
            {
                lock (eventlockb)
                {
                    frameBlocked += value;
                    isFrameBlockedSignalReady = true;
                }
            }
            remove
            {
                lock (eventlockb)
                {
                    frameBlocked -= value;
                    isFrameBlockedSignalReady = frameBlocked != null;
                }
            }
        }
        protected ProcessInterruptSignal frameBlocked;

        public CameraService() { }
        public CameraService(SecurityCamera camera)
        {
            this.facade = camera;
        }

        public void SetLoginHandle(object handle) => loginHandle = handle;
        protected virtual void StopDecoding() { }

        /// <summary>
        /// 实时播放
        /// </summary>
        public virtual void PlayReal() { }

        /// <summary>
        /// 暂停播放
        /// </summary>
        /// <remarks>不建议调用 DHPlaySDK.PLAY_Pause ,因为画面会一直延迟下去</remarks>
        public virtual void Pause()
        {
            if (IsRealPlaying && !isPause)
            {
                isPause = true;
            }
        }

        /// <summary>
        /// 恢复播放
        /// </summary>
        public virtual void Resume()
        {
            if (IsRealPlaying && isPause)
            {
                isPause = false;
            }
        }

        /// <summary>
        /// 结束播放
        /// </summary>
        public virtual void StopPlay()
        {
            isPause = false;
        }
    }
    /// <summary>
    /// Delegate used for events when an I420-encoded video frame has been produced
    /// and is ready for consumption.
    /// </summary>
    /// <param name="frame">The newly available I420-encoded video frame.</param>
    public delegate void I420AVideoFrameDelegate(I420VideoFrame frame);
    public delegate bool ProcessInterruptSignal();
}
