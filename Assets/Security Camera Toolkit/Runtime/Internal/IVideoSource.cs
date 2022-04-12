// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

namespace zFramework.Media
{
    /// <summary>
    /// Interface for video sources.
    /// <br>可提供视频源的接口</br>
    /// <br>这种写法，可以让一个视频源向多个 VideoRenderer 提供视频信息，但是，不要这样做</br>
    /// <br>如果你想多个 RawImage 播放同一个画面，可以公用材质球吖，对不对？</br>
    /// </summary>
    public interface IVideoSource
    {
        /// <summary>
        /// Event that occurs when a new video frame is available from the source
        /// <para>当视频源（SDK 播放库）广播一个新的 视频帧时触发的事件</para>
        /// </summary>
        /// <remarks>
        /// The event delivers to the handlers an I422-encoded video frame.
        /// <para>事件传递的是一个 YUV 编码的视频原始数据的指针。</para>
        /// This event is invoked on the Security Camera SDK thread. Can not call unity object directly.
        /// <para>事件由监控 SDK 中的解码线程分发，数据不可直接用于 Unity Object，譬如UI</para>
        /// </remarks>
        event I422AVideoFrameDelegate OnVideoFrameReady;
        /// <summary>
        /// 设计由 VideoRenderer 提供中断事件,避免推送冗余数据和不必要的数据对拷
        /// </summary>
        event ProcessInterruptSignal OnInterruptedSignal;

        /// <summary>
        /// 如果 解码器 配置成功则为 true ，目前返回的是 realplay 句柄是否成功获取
        /// </summary>
        bool Enabled { get; }
    }
}
