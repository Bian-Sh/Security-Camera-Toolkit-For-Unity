// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using Hikvision;
using System;
using UnityEngine;
using static zFramework.Media.DHPlaySDK;

namespace zFramework.Media
{
    public class HKCameraPlayer : SecurityCameraPalyer
    {
        //loginHandle 海康是 int 类型 ，小于 -1 代表未成功登录

        protected override bool HasLogin => (int)(loginHandle??-1) > -1;
        protected override bool IsPlaying => realHandle > -1;

        //RealPlay 返回句柄参数，-1代表实时播放失败。
        private int realHandle = -1;
        private CHCNetSDK.REALDATACALLBACK realDataBack;
        public override void PlayReal()
        {
            if (HasLogin && !IsPlaying)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO previewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                previewInfo.hPlayWnd = IntPtr.Zero;
                previewInfo.lChannel = base.data.channel;
                previewInfo.dwStreamType = (uint)STREAM.MAIN;
                previewInfo.dwLinkMode = 0;
                previewInfo.bBlocked = true;
                previewInfo.dwDisplayBufNum = 15;
                realDataBack = new CHCNetSDK.REALDATACALLBACK(DataBackFunc);
                realHandle = CHCNetSDK.NET_DVR_RealPlay_V40((int)loginHandle, ref previewInfo, realDataBack, IntPtr.Zero);
                if (realHandle > -1)
                {
                    Debug.Log($" { base.data.channel } 实时预览成功");
                }
                else
                {
                    Debug.Log($"预览失败 - { CHCNetSDK.NET_DVR_GetLastError()}");
                }
            }
            else
            {
                Debug.Log($"播放操作失败：{(HasLogin ? "已经在播放中" : "还没有登录")}");
            }
        }



        private int lPort = -1;
        private DECCBFUN decondCallBack;
        private void DataBackFunc(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            //需要解码
            if (lPort <= -1)
            {
                if (!DHPlaySDK.PLAY_GetFreePort(ref lPort))
                {
                    Debug.LogWarning($"分配播放库通道号失败：  {DHPlaySDK.PLAY_GetLastErrorEx()}");
                    return;
                }

                if (!DHPlaySDK.PLAY_SetStreamOpenMode(lPort, HasLogin ? DHPlaySDK.STREAME_FILE : DHPlaySDK.STREAME_REALTIME))
                {
                    Debug.LogWarning($"设置实时流播放模式失败：{DHPlaySDK.PLAY_GetLastErrorEx()}");
                    return;
                }
                if (!DHPlaySDK.PLAY_OpenStream(lPort, IntPtr.Zero, 0, 2 * 1024 * 1024))
                {
                    Debug.LogWarning($"打开码流失败! {DHPlaySDK.PLAY_GetLastErrorEx()}");
                    return;
                }
                decondCallBack = new DECCBFUN(DecodeCallback);
                if (!DHPlaySDK.PLAY_SetDecCallBack(lPort, decondCallBack))
                {
                    Debug.LogWarning($"设置解码回调函数失败! {0}");
                    return;
                }

                if (!DHPlaySDK.PLAY_SetDecCBStream(lPort, 3))
                {
                    Debug.Log($"设置解码格式! {0}");
                    return;
                }

                if (!DHPlaySDK.PLAY_Play(lPort, IntPtr.Zero))
                {
                    Debug.Log($"开始解码失败! { DHPlaySDK.PLAY_GetLastErrorEx()}");
                    return;
                }
                DHPlaySDK.PLAY_SetPlaySpeed(lPort, 1f);
            }
            else if (dwBufSize > 0)
            {
                if (!DHPlaySDK.PLAY_InputData(lPort, pBuffer, dwBufSize))
                {
                    Debug.LogWarning($"{nameof(HKCameraPlayer)}: 播放库数据装载失败 errorcode = {DHPlaySDK.PLAY_GetLastErrorEx()}");
                }
            }
        }
        public HKCameraPlayer(CameraInfomation info) : base(info)
        {
        }

        private void DecodeCallback(int nPort, IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, IntPtr pUserData, int nReserved2)
        {
            if (IsPlaying &&!isPause&& pFrameInfo.nType == 3)
            {
                var frame = new I420AVideoFrame
                {
                    width = (uint)pFrameInfo.nWidth,
                    height = (uint)pFrameInfo.nHeight,
                    buffer = pBuf
                };
                fremeReady(frame);
            }
        }

        public override void StopPlay()
        {
            StopDecoding();
            if (realHandle > -1)
            {
                var temp = realHandle; //避免多次访问 SDK 
                realHandle = -1;
                var result = CHCNetSDK.NET_DVR_StopRealPlay(temp);
                Debug.Log($"{nameof(HKCameraPlayer)}: 停止实时播放{(result ? "成功" : "失败")}");
            }
            base.StopPlay();
        }

        protected override void StopDecoding()
        {
            if (lPort > -1)
            {
                var temp = lPort;
                lPort = -1;
                if (!DHPlaySDK.PLAY_Stop(temp))
                {
                    Debug.Log($"停止解码失败， ErrorCode = {DHPlaySDK.PLAY_GetLastErrorEx()}");
                }
                if (!DHPlaySDK.PLAY_CloseStream(temp))
                {
                    Debug.Log($"关闭解码流失败，ErrorCode = {DHPlaySDK.PLAY_GetLastErrorEx()}");
                }
            }
        }
    }
}