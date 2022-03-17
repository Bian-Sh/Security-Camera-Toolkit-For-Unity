using System;
using System.Runtime.InteropServices;

namespace zFramework.Media
{
    /// <summary>
    /// 大华播放库
    /// </summary>
    public class DHPlaySDK
    {
        [DllImport("dhplay")]
        public static extern bool PLAY_GetFreePort(ref int plPort);

        //播放模式：STREAME_REALTIME实时模式(默认);STREAME_FILE文件流模式;实时模式,适合播放网络实时数据;文件模式,适合用户把文件数据用流方式输入。 
        public const int STREAME_REALTIME = 0;
        public const int STREAME_FILE = 1;
        [DllImport("dhplay")]
        public static extern bool PLAY_SetStreamOpenMode(int nPort, int nMode);

        /// <summary>
        /// 打开流播放
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="pFileHeadBuf">目前不使用，填为NULL </param>
        /// <param name="nSize">目前不使用，填为0 </param>
        /// <param name="nBufPoolSize">设置播放器中存放数据流的缓冲区大小。范围是[SOURCE_BUF_MIN, SOURCE_BUF_MAX]。一般设为900*1024，如果数据送过来相对均匀，可调小该值，如果数据传输不均匀，可增大该值。</param>
        /// <returns>成功返回TRUE，不成功返回FALSE</returns>
        [DllImport("dhplay")]
        public static extern bool PLAY_OpenStream(int nPort, IntPtr pFileHeadBuf, uint nSize, uint nBufPoolSize);

        public struct FRAME_INFO
        {
            public int nWidth;
            public int nHeight;
            public int nStamp;
            public int nType;//视频帧类型,T_AUDIO16,T_RGB32,T_IYUV 
            public int nFrameRate;
        };
        public delegate void DECCBFUN(int nPort, IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, IntPtr pUserData, int nReserved2);
        [DllImport("dhplay")]
        public static extern bool PLAY_SetDecCallBack(int nPort, DECCBFUN DecCBFun);

        /// <summary>
        /// 设置解码回调流类型
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="nStream">流类型：1 视频流;2 音频流;3 复合流; </param>
        /// <returns></returns>
        [DllImport("dhplay")]
        public static extern bool PLAY_SetDecCBStream(int nPort, int nStream);

        [DllImport("dhplay")]
        public static extern bool PLAY_Play(int nPort, IntPtr hWnd);

        [DllImport("dhplay")]
        public static extern bool PLAY_InputData(int nPort, IntPtr pBuf, uint nSize);

        [DllImport("dhplay")]
        public static extern bool PLAY_Stop(int nPort);

        [DllImport("dhplay")]
        public static extern bool PLAY_CloseStream(int nPort);

        [DllImport("dhplay")]
        public static extern int PLAY_GetLastErrorEx();

        [DllImport("dhplay")]
        public static extern bool PLAY_Pause(int nPort, bool nPause);

        [DllImport("dhplay")]
        public static extern bool PLAY_Fast(int nPort);

        [DllImport("dhplay")]
        public static extern bool PLAY_Slow(int nPort);

        //播放速度,范围[1/64~64.0],小于1表示慢放，大于1表示正放. 
        [DllImport("dhplay")]
        public static extern bool PLAY_SetPlaySpeed(int nPort, float fCoff);

        //播放指针的相对位置的百分比 
        [DllImport("dhplay")]
        public static extern bool PLAY_SetPlayPos(int nPort, float fRelativePos);

        [DllImport("dhplay")]
        public static extern float PLAY_GetPlayPos(int nPort);

        [DllImport("dhplay")]
        public static extern bool PLAY_ResetSourceBuffer(int nPort);
    }
}
