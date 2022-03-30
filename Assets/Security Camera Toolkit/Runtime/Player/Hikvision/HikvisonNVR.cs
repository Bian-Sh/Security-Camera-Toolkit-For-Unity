// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using Hikvision;
using System.Threading.Tasks;
using UnityEngine;
namespace zFramework.Media
{
    public class HikvisonNVR : NVR
    {
        /// <summary>
        /// 断言 NVR 是否登录
        /// </summary>
        public override bool IsLogin => null != loginHandle && (int)loginHandle > -1;//(int)(loginHandle??-1)> -1;

        public HikvisonNVR(NVRInformation data) : base(data) { }

        public override bool CleanUp()
        {
            var state = CHCNetSDK.NET_DVR_Cleanup();
            if (!state)
            {
                Debug.LogError($"{nameof(HikvisonNVR)}: SDK 初始化失败");
            }
            return state;
        }

        public override bool InitSDK()
        {
            CHCNetSDK.NET_DVR_SetConnectTime(2000, 3);
            CHCNetSDK.NET_DVR_SetReconnect(1000, 1);
            var state = CHCNetSDK.NET_DVR_Init();
            if (!state)
            {
                Debug.LogError($"{nameof(HikvisonNVR)}: SDK 初始化失败");
            }
            return state;
        }

        /// <summary>
        /// <inheritdoc/>
        /// <br>异步操作的 API ，请在调用保持克制，在 UI 层面做一个互锁，简易示例见 NVRController</br>
        /// </summary>
        /// <returns></returns>
        public override async Task LoginAsync()
        {
            if (!IsLogin)
            {
                var result = await Task.Run(() =>
                {
                    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                    loginHandle = CHCNetSDK.NET_DVR_Login_V30(data.Ip, (int)data.Port, data.userName, data.password, ref DeviceInfo);
                    var result = (int)loginHandle != -1;
                    if (result)
                    {
                        // 向挂载的监控发送 登录状态 , 注意，此动作在非Unity主线程中进行
                        Debug.Log($"{data.type} - {data.ActiveHost} NVR 登录成功：{loginHandle}");
                    }
                    else
                    {
                        Debug.LogWarning($"{data.type} - {data.ActiveHost} NVR 登录失败,ErrorCode = {CHCNetSDK.NET_DVR_GetLastError()}");
                    }
                    return result;
                });
                if (result)
                {
                    await base.LoginAsync();
                    Debug.Log($"{nameof(HikvisonNVR)}: 所有 SecurityCamera 同步 NVR 登录状态成功");
                }
            }
            else
            {
                Debug.Log($"{data.type} - {data.ActiveHost} SDK 已经登录");
            }
        }

        public override async Task LogoutAsync()
        {
            if (IsLogin)
            {
                // 登出事件的广播必须先通知到各个监控，在登出前需确保各个监控停止播放
                await base.LogoutAsync();
                await Task.Run(() =>
                    {
                        var state = CHCNetSDK.NET_DVR_Logout_V30((int)loginHandle);
                        if (state)
                        {
                            loginHandle = null;
                            Debug.Log($"{nameof(HikvisonNVR)}: {data.ActiveHost} - {loginHandle} 登出成功");
                        }
                        else
                        {
                            Debug.LogWarning($"{nameof(HikvisonNVR)}: {data.ActiveHost} - {loginHandle} 登出失败");
                        }
                    });
            }
        }
    }
}