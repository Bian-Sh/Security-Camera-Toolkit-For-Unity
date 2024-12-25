using System;
using System.Runtime.InteropServices;
using NETSDKHelper;
using UnityEngine;
using UnityEngine.EventSystems;

namespace zFramework.Media
{
    public class UVService : CameraService
    {
        //public override bool HasLogin => (loginHandle);
        
        //RealPlay 返回句柄参数，-1代表实时播放失败。
        private IntPtr realHandle = IntPtr.Zero;
        
        public override bool HasLogin => (IntPtr)loginHandle != IntPtr.Zero;
        
        public override bool IsRealPlaying => realHandle != IntPtr.Zero;




        private NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF _decodeVideoDataCallbackPf;
        
        NETDEVSDK.NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF videoDataCB;

        public override void PlayReal()
        {
            Debug.Log("实时预览调用");
            NETDEV_PREVIEWINFO_S stNetInfo = new NETDEV_PREVIEWINFO_S();
            stNetInfo.dwChannelID = facade.channel;
            stNetInfo.hPlayWnd = IntPtr.Zero;
            stNetInfo.dwStreamType = 0;
            stNetInfo.dwLinkMode = 1;
            
            IntPtr cbPlayDataCallback = IntPtr.Zero;
            realHandle = NETDEVSDK.NETDEV_RealPlay((IntPtr)loginHandle, ref stNetInfo, cbPlayDataCallback, IntPtr.Zero);
            
            if (realHandle == IntPtr.Zero)
            {
                Debug.LogError($"实时预览失败： {NETDEVSDK.NETDEV_GetLastError()}");
            }
            else
            {
                // //注册解码后视频媒体流数据
                // int playDecodeVideoCBHandel = NETDEVSDK.NETDEV_SetPlayDecodeVideoCB(realHandle, CbPlayDecodeVideoCallBack, 1, IntPtr.Zero);
                //
                // if (playDecodeVideoCBHandel != 1)
                // {
                //     Debug.Log($"注册解码后视频媒体流数据失败: {playDecodeVideoCBHandel}, {NETDEVSDK.NETDEV_GetLastError()}");
                // }
                
                videoDataCB = new NETDEVSDK.NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(VideoDataCallBack);
                IntPtr cbPtr = Marshal.GetFunctionPointerForDelegate(videoDataCB);
                int iRet = NETDEVSDK.NETDEV_SetPlayDecodeVideoCB(realHandle, videoDataCB, 1, IntPtr.Zero);
                if (iRet == 1)
                {
                    Debug.Log("实时监控画面接收成功");
                }
                else
                {
                    Debug.LogError($"实时监控画面接收失败: {NETDEVSDK.NETDEV_GetLastError()}");
                }
            }
            
            


            //NETDEVSDK.NETDEV_SetPlayParseCB(realHandle, IntPtr.Zero, bContinue, IntPtr.Zero);
            
            // //注册解码后视频媒体流数据
            //NETDEVSDK.NETDEV_SetPlayDataCallBack(realHandle, IntPtr.Zero, 1, IntPtr.Zero);
            // //设置显示后数据回调
            // NETDEVSDK.NETDEV_SetPlayDisplayCB(realHandle, IntPtr.Zero, IntPtr.Zero);
            
            // NETDEVSDK.NETDEV_SetIVAEnable(realHandle, 1);
            // NETDEVSDK.NETDEV_SetIVAShowParam(7);
            
            

            // if (iRet == NETDEVSDK.TRUE)
            // {
            //     NETDEVSDK.NETDEV_DISPLAY_CALLBACK_PF displayCB = new NETDEVSDK.NETDEV_DISPLAY_CALLBACK_PF(DisplayCallBack);
            //     IntPtr displayPtr = Marshal.GetFunctionPointerForDelegate(displayCB);
            //     iRet = NETDEVSDK.NETDEV_SetPlayDisplayCB(realHandle, displayPtr, IntPtr.Zero);
            // }

        }
        public void VideoDataCallBack(IntPtr lpUserId, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserParam)
        {
            if (IsRealPlaying && !isPause)
            {
                // 先访问 VideoRenderer 是否视频帧队列已满，满了就把当前推进来的数据不管
                var blocked = frameBlocked?.Invoke() ?? true;
                
                if (!blocked)
                {
                    NETDEV_PICTURE_DATA_S temp = pstPictureData;

                    var fream = new I422VideoFrame(temp.dwPicWidth, temp.dwPicHeight, temp.pucData[0], temp.pucData[1], temp.pucData[2]);

                    frameReady?.Invoke(fream);
                }
            }
        }


        public UVService(SecurityCamera facade) : base(facade) { }
        private void CbPlayDecodeVideoCallBack(IntPtr lprealhandle, ref NETDEV_PICTURE_DATA_S pstpicturedata, IntPtr lpuserparam)
        {
            Debug.Log("1");
            if (IsRealPlaying && !isPause)
            {
                // 先访问 VideoRenderer 是否视频帧队列已满，满了就把当前推进来的数据不管
                var blocked = frameBlocked?.Invoke() ?? true;
                
                if (!blocked)
                {
                    NETDEV_PICTURE_DATA_S temp = pstpicturedata;

                    var fream = new I422VideoFrame(temp.dwPicWidth, temp.dwPicHeight, temp.pucData[0], temp.pucData[1], temp.pucData[2]);

                    frameReady?.Invoke(fream);
                }
            }
        }

        public override void StopPlay()
        {
            StopDecoding();

            if (realHandle != IntPtr.Zero)
            {
                var temp = realHandle; //避免多次访问 SDK 
                realHandle = IntPtr.Zero;
                var result = NETDEVSDK.NETDEV_StopRealPlay(temp);

                if (result != 1)
                {
                    Debug.Log($"{nameof(UVService)} {result},    停止实时播放失败：{NETDEVSDK.NETDEV_GetLastError()}");
                }
            }
        }


        
        private int currentDirection;  // 当前方向

        // public void OnPointerDown(BaseEventData eventData)
        // {
        //     
        //     if (eventData.selectedObject.name.Equals("ButtonUp"))
        //     {
        //     	currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTUP;
        //     }
        //     else if (eventData.selectedObject.name.Equals("ButtonDown"))
        //     {
        //     	currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTDOWN;
        //     }
        //     else if (eventData.selectedObject.name.Equals("ButtonLeft"))
        //     {
        //     	currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_PANLEFT;
        //     }
        //     else if (eventData.selectedObject.name.Equals("ButtonRight"))
        //     {
        //     	currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_PANRIGHT;
        //     }
        // }
        //
        // private void StartPTZControl(BaseEventData eventData)
        // {
        //     NETDEVSDK.NETDEV_PTZControl_Other((IntPtr)loginHandle, facade.channel, currentDirection, 6);
        // }
        // private void StopPTZControl(BaseEventData eventData)
        // {
        //     NETDEVSDK.NETDEV_PTZControl_Other((IntPtr)loginHandle, facade.channel, currentDirection, 6);
        // }


        public override void PTZUp()
        {
            base.PTZUp();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTUP;
            
            int ptzControlUp = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlUp != 1)
            {
                Debug.LogError($"云台控制向上失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
            else
            {
                Debug.Log($"云台控制成功: {ptzControlUp}");
            }
        }

        public override void PTZDown()
        {
            base.PTZDown();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTDOWN;
            
            int ptzControlDown = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);

            if (ptzControlDown != 1)
            {
                Debug.LogError($"云台控制向下失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        public override void PTZLeft()
        {
            base.PTZLeft();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_PANLEFT;
            
            int ptzControlLeft = NETDEVSDK.NETDEV_PTZControl_Other((IntPtr)loginHandle, facade.channel, currentDirection, 6);

            if (ptzControlLeft != 1)
            {
                Debug.LogError($"云台控制向左失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        public override void PTZRight()
        {
            base.PTZRight();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_PANRIGHT;
            
            int ptzControlRight = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlRight != 1)
            {
                Debug.LogError($"云台控制向右失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        public override void PTZUpLeft()
        {
            base.PTZUpLeft();
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTUP;
            
            int ptzControlRight = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlRight != 1)
            {
                Debug.LogError($"云台控制左上失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        public override void PTZUpRight()
        {
            base.PTZUpRight();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTUP;
            
            int ptzControlRight = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlRight != 1)
            {
                Debug.LogError($"云台控制左上失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }
        
        public override void PTZDownLeft()
        {
            base.PTZDownLeft();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTDOWN;
            
            int ptzControlRight = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlRight != 1)
            {
                Debug.LogError($"云台控制左上失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        public override void PTZDownRight()
        {
            base.PTZDownRight();
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTDOWN;
            
            int ptzControlRight = NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
            
            if (ptzControlRight != 1)
            {
                Debug.LogError($"云台控制左上失败: {NETDEVSDK.NETDEV_GetLastError()}");
            }
        }

        /// <summary>
        /// 放大
        /// </summary>
        public override void ZOOMMtele()
        {
            base.ZOOMMtele();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMTELE;
            NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
        }

        /// <summary>
        /// 缩小
        /// </summary>
        public override void ZOOMWide()
        {
            base.ZOOMWide();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMWIDE;
            NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
        }

        /// <summary>
        /// 暂停所有
        /// </summary>
        public override void PTZAllStop()
        {
            base.PTZAllStop();
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP;
            NETDEVSDK.NETDEV_PTZControl((IntPtr)realHandle, currentDirection, 6);
        }

        public override void FocusNear()
        {
            base.FocusNear();

            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSNEAR;
            NETDEVSDK.NETDEV_PTZControl(realHandle, currentDirection, 6);
        }
        
        public override void FocusFar()
        {
            base.FocusFar();
            
            currentDirection = (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSNEAR;
            NETDEVSDK.NETDEV_PTZControl(realHandle, currentDirection, 6);
        }
        
        

        public void PlayBackByTime()
        {
            NETDEV_FINDDATA_S finddataS = new NETDEV_FINDDATA_S();
            
            // NETDEV_PLAYBACKCOND_S stPlayBackInfo = new NETDEV_PLAYBACKCOND_S();
            // stPlayBackInfo.dwChannelID = 1;
            // stPlayBackInfo.tBeginTime = 
        }
    }
}