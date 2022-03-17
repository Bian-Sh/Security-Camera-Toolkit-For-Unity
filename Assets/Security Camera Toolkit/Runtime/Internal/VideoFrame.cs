// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;

namespace zFramework.Media
{
    /// <summary>
    /// Single video frame encoded in I420A format , YUV Raw data
    /// See e.g. https://wiki.videolan.org/YUV/#I420 for details.
    /// </summary>
    public ref struct I420AVideoFrame
    {
        /// <summary>
        /// Frame width, in pixels.
        /// </summary>
        public uint width;

        /// <summary>
        /// Frame height, in pixels.
        /// </summary>
        public uint height;

        /// <summary>
        /// 帧数据
        /// </summary>
        public IntPtr buffer;

    }

    /// <summary>
    /// Delegate used for events when an I420-encoded video frame has been produced
    /// and is ready for consumption.
    /// </summary>
    /// <param name="frame">The newly available I420-encoded video frame.</param>
    public delegate void I420AVideoFrameDelegate(I420AVideoFrame frame);

}