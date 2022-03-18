// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

namespace zFramework.Media
{
    /// <summary>
    /// Interface for video sources.
    /// <para>可提供视频源的接口</para>
    /// </summary>
    public interface IVideoSource
    {
        /// <summary>
        /// Event that occurs when a new video frame is available from the source
        /// <para>当视频源（SDK 播放库）广播一个新的 视频帧时触发的事件</para>
        /// </summary>
        /// <remarks>
        /// The event delivers to the handlers an I420-encoded video frame.
        /// <para>事件传递的是一个 YUV 编码的视频原始数据的指针。</para>
        /// This event is invoked on the Security Camera SDK thread. Can not call unity object directly.
        /// <para>事件由监控 SDK 中的解码线程分发，数据不可直接用于 Unity Object，譬如UI</para>
        /// </remarks>
        event I420AVideoFrameDelegate OnVideoFrameReady;

        /// <summary>
        /// 如果 解码器 配置成功则为 true ，但是目前返回的是 realplay 句柄是否成功获取
        /// </summary>
        bool Enabled { get; }
    }
}
