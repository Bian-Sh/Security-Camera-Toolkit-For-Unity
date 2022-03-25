// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;

namespace zFramework.Media
{
    /// <summary>
    /// Single video frame encoded in I420A format , YUV Raw data
    /// See e.g. https://wiki.videolan.org/YUV/#I420 for details.
    /// </summary>
    public ref struct I420VideoFrame
    {
        /// <summary>
        /// Frame width, in pixels.
        /// </summary>
        public int width;

        /// <summary>
        /// Frame height, in pixels.
        /// </summary>
        public int height;

        private byte[] buffer_Y;
        private byte[] buffer_U;
        private byte[] buffer_V;
        private int lumasize;
        private int chromasize;

        private I420VideoFrame(int width, int height)
        {
            this.width = width;
            this.height = height;
            lumasize = width * height;
            chromasize = (width / 2) * (height / 2); //方便理解，不写成 lumasize/4
            buffer_Y = new byte[lumasize];
            buffer_U = new byte[chromasize];
            buffer_V = new byte[chromasize];
        }
        public I420VideoFrame(int width, int height, IntPtr yuv) : this(width, height) => Copy(yuv);
        public I420VideoFrame(int width, int height, IntPtr src_y, IntPtr src_u, IntPtr src_v) : this(width, height) => Copy(src_y, src_u, src_v);


        //大华播放库返回的是 YUV IntPtr 类型的打包数据,需要拆分开来
        private void Copy(IntPtr yuv)
        {
            unsafe
            {
                fixed (void* ptr_y = buffer_Y)
                fixed (void* ptr_u = buffer_U)
                fixed (void* ptr_v = buffer_V)
                {
                    Buffer.MemoryCopy((void*)yuv, ptr_y, lumasize, lumasize);
                    yuv += lumasize;
                    Buffer.MemoryCopy((void*)yuv, ptr_u, chromasize, chromasize);
                    yuv += chromasize;
                    Buffer.MemoryCopy((void*)yuv, ptr_v, chromasize, chromasize);
                }
            }
        }

        //宇视播放库返回的是 Y、U、V  3个 IntPtr 类型的分片数据
        private void Copy(IntPtr scr_y, IntPtr scr_u, IntPtr scr_v)
        {
            unsafe
            {
                fixed (void* ptr_y = buffer_Y)
                fixed (void* ptr_u = buffer_U)
                fixed (void* ptr_v = buffer_V)
                {
                    Buffer.MemoryCopy((void*)scr_y, ptr_y, lumasize, lumasize);
                    Buffer.MemoryCopy((void*)scr_u, ptr_u, chromasize, chromasize);
                    Buffer.MemoryCopy((void*)scr_v, ptr_v, chromasize, chromasize);
                }
            }
        }

        public void ApplyTo<T>(T target) where T : class, IVideoFrameStorage, new()
        {
            target.Height = height;
            target.Width = width;
            target.Buffer_Y = buffer_Y;
            target.Buffer_U = buffer_U;
            target.Buffer_V = buffer_V;
        }
    }

}