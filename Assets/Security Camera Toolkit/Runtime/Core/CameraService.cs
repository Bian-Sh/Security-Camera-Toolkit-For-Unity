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
        public bool isPause = false;
        object eventlocka = new object();
        object eventlockb = new object();
        protected bool isVideoRendererReady = false;
        protected bool isFrameBlockedSignalReady = false;
        /// <inheritdoc/>
        public event I422AVideoFrameDelegate OnVideoFrameReady
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
        protected I422AVideoFrameDelegate frameReady;
        /// <inheritdoc/>
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
        public CameraService(SecurityCamera camera) => facade = camera;

        public void SetLoginHandle(object handle) => loginHandle = handle;
        protected virtual void StopDecoding() { }

        /// <summary>
        /// 实时播放
        /// </summary>
        public virtual void PlayReal() { }

        /// <summary>
        /// 暂停播放
        /// </summary>
        public virtual void Pause() => isPause = true;

        /// <summary>
        /// 恢复播放
        /// </summary>
        public virtual void Resume() => isPause = false;

        /// <summary>
        /// 结束播放
        /// </summary>
        public virtual void StopPlay() => isPause = false;
        
        public virtual void PTZUp() {}
        
        public virtual void PTZDown(){}
        public virtual void PTZLeft(){}
        public virtual void PTZRight(){}
        
        public virtual void PTZUpLeft(){}
        
        public virtual void PTZUpRight(){}
        
        public virtual void PTZDownLeft(){}
        public virtual void PTZDownRight(){}
        
        public virtual void ZOOMMtele(){}
        public virtual void ZOOMWide(){}
        
        public virtual void FocusNear(){}
        public virtual void FocusFar(){}
        
        public virtual void PTZAllStop(){}
    }
    /// <summary>
    /// Delegate used for events when an I422-encoded video frame has been produced
    /// and is ready for consumption.
    /// </summary>
    /// <param name="frame">The newly available I422-encoded video frame.</param>
    public delegate void I422AVideoFrameDelegate(I422VideoFrame frame);
    public delegate bool ProcessInterruptSignal();
}
