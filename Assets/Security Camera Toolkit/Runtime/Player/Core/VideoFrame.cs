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
        public IntPtr buffer_Y;
        public IntPtr buffer_U;
        public IntPtr buffer_V;

        public void CopyTo<T>(T storage) where T : class, IVideoFrameStorage, new()
        {
            // YUV 数据长度分别是 size ，size/4 , size/4
            var lumasize = width * height;  // luma ：亮度
            var chromasize = (width / 2) * (height / 2); // chroma : 色度

            storage.Buffer_Y = new byte[lumasize];
            storage.Buffer_U = new byte[chromasize];
            storage.Buffer_V = new byte[chromasize];

            //提供 二选一 的储值方案，如果 buffer 无效则处理 YUV 分片数据
            //宇视播放库返回的是 Y、U、V  3个 IntPtr 类型的分片数据
            //大华播放库返回的是 YUV IntPtr 类型的打包数据
            if (buffer != default)
            {
                unsafe
                {
                    fixed (void* ptr_y = storage.Buffer_Y)
                    fixed (void* ptr_u = storage.Buffer_U)
                    fixed (void* ptr_v = storage.Buffer_V)
                    {
                        Buffer.MemoryCopy((void*)buffer, ptr_y, lumasize, lumasize);
                        buffer += (int)lumasize;
                        Buffer.MemoryCopy((void*)buffer, ptr_u, chromasize, chromasize);
                        buffer += (int)chromasize;
                        Buffer.MemoryCopy((void*)buffer, ptr_v, chromasize, chromasize);
                    }
                }
            }
            else
            {
                unsafe
                {
                    fixed (void* ptr_y = storage.Buffer_Y)
                    fixed (void* ptr_u = storage.Buffer_U)
                    fixed (void* ptr_v = storage.Buffer_V)
                    {
                        Buffer.MemoryCopy((void*)buffer_Y, ptr_y, lumasize, lumasize);
                        Buffer.MemoryCopy((void*)buffer_U, ptr_u, chromasize, chromasize);
                        Buffer.MemoryCopy((void*)buffer_V, ptr_v, chromasize, chromasize);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Delegate used for events when an I420-encoded video frame has been produced
    /// and is ready for consumption.
    /// </summary>
    /// <param name="frame">The newly available I420-encoded video frame.</param>
    public delegate void I420AVideoFrameDelegate(I420AVideoFrame frame);

}