// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    public class CameraService : IVideoSource
    {
        public CameraInfomation data;
        public object loginHandle; //登录句柄，数据类型：int 、c#指针 
        protected virtual bool HasLogin { get; }
        protected virtual bool IsPlaying { get; }
        public bool Enabled => IsPlaying;

        //暂停
        protected bool isPause = false;
        object eventlock = new object();
        protected bool isVideoRendererReady = false;
        /// <summary>
        /// 视频帧广播事件
        /// </summary>
        public event I420AVideoFrameDelegate OnVideoFrameReady
        {
            add
            {
                lock (eventlock)
                {
                    fremeReady += value;
                    isVideoRendererReady = true;
                }
            }
            remove
            {
                lock (eventlock)
                {
                    fremeReady -= value;
                    isVideoRendererReady = fremeReady != null;
                }
            }
        }
        protected I420AVideoFrameDelegate fremeReady;

        public CameraService(CameraInfomation info)
        {
            this.data = info;
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
            if (IsPlaying&&!isPause)
            {
                isPause = true;
            }
        }

        /// <summary>
        /// 恢复播放
        /// </summary>
        public virtual void Resume() 
        {
            if (IsPlaying&&isPause)
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
}
