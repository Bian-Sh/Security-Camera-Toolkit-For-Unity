using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NETSDKHelper;
using UnityEngine;
using zFramework.Media;

public class UniviewNVR : NVR
{
    public override bool IsLogin => loginHandle != null && (IntPtr)loginHandle != IntPtr.Zero;


    public UniviewNVR(NVRInformation data) : base(data) { }

    public override bool CleanUp()
    {
        NETDEVSDK.NETDEV_Cleanup();

        return true;
    }

    public override bool InitSDK()
    {
        NETDEV_REV_TIMEOUT_S revTimeoutS = new NETDEV_REV_TIMEOUT_S();
        revTimeoutS.dwRevTimeOut = 5;
        revTimeoutS.dwFileReportTimeOut = 30;

        NETDEVSDK.NETDEV_SetRevTimeOut(ref revTimeoutS);

        NETDEVSDK.NETDEV_SetLogPath(Path.Combine(Application.streamingAssetsPath, "log"));
        var state = NETDEVSDK.NETDEV_Init();

        return true;
    }



    public override async Task LoginAsync()
    {
        if (!IsLogin)
        {
            var resultState = await Task.Run(() =>
            {
                NETDEV_DEVICE_LOGIN_INFO_S stDevLoginInfo = new NETDEV_DEVICE_LOGIN_INFO_S();

                stDevLoginInfo.szIPAddr = data.Ip;
                stDevLoginInfo.szUserName = data.userName;
                stDevLoginInfo.szPassword = data.password;
                stDevLoginInfo.dwPort = (int)data.Port;
                stDevLoginInfo.dwLoginProto = (int)NETDEV_LOGIN_PROTO_E.NETDEV_LOGIN_PROTO_ONVIF;

                NETDEV_SELOG_INFO_S stSELogInfo = new NETDEV_SELOG_INFO_S();

   
                loginHandle = NETDEVSDK.NETDEV_Login_V30(ref stDevLoginInfo, ref stSELogInfo);
                
                var result = (IntPtr)loginHandle != IntPtr.Zero;
                if (result)
                {
                    Debug.Log($"{data.type} - {data.ActiveHost} NVR 登录成功：{loginHandle}");
                }
                else
                {
                    Debug.LogWarning($"{data.type} - {data.ActiveHost} NVR 登录失败,ErrorCode = {NETDEVSDK.NETDEV_GetLastError()}");

                }
                    
                return result;
            });

            if (resultState)
            {
                await base.LoginAsync();
                Debug.Log($"{nameof(UVService)}: 所有 SecurityCamera 同步 NVR 登录状态成功");
            }
        }
        else
        {
            Debug.Log($"{data.type} - {data.ActiveHost} SDK 已经登录");
        }
        
        Debug.Log($"{IsLogin},   {loginHandle}");
    }


    public override async Task LogoutAsync()
    {
        if (IsLogin)
        {
            await base.LogoutAsync();
            await Task.Run(() =>
            {
                var state = NETDEVSDK.NETDEV_Logout((IntPtr)loginHandle);
                // if (state)
                // {
                //     loginHandle = null;
                //     Debug.Log($"{nameof(UniviewNVR)}: {data.ActiveHost} - {loginHandle} 登出成功");
                // }
                // else
                // {
                //     Debug.LogWarning($"{nameof(UniviewNVR)}: {data.ActiveHost} - {loginHandle} 登出失败");
                // }
            });
        }
    }
}
