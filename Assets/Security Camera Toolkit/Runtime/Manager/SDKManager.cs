// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using Hikvision;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace zFramework.Media
{
    /// <summary>
    /// 如果不知道里面写了什么，不要自己调用这个静态类的方法
    /// </summary>
    public static class SDKManager
    {
        /// <summary>
        /// SDK 登录成功后返回的 handle 集合
        /// </summary>
        static Dictionary<SDK, Dictionary<string, object>> loginHandles;

        static SDKManager()
        {
            loginHandles = new Dictionary<SDK, Dictionary<string, object>>();
        }

        /// <summary>
        ///  根据监控类型初始化，每个类型只初始化一次
        /// </summary>
        /// <param name="type">监控类型</param>
        public static void InitSDK(SDK type)
        {
            //约定：SDK 是否完成初始化的标志是：loginHanles 字典中是否存在该 SDK Type 的键值，存在则说明已经完成初始化
            if (!loginHandles.TryGetValue(type, out Dictionary<string, object> handles))
            {
                bool result = false;
                switch (type)
                {
                    case SDK.HK:
                        CHCNetSDK.NET_DVR_SetConnectTime(2000, 3);
                        CHCNetSDK.NET_DVR_SetReconnect(1000, 1);
                        result = CHCNetSDK.NET_DVR_Init(); //由于其他品牌
                        break;
                    case SDK.DH:
                    case SDK.YS:
                        break;
                }
                //仅当 SDK 报告初始化成功后记录 key ，否则错误提醒
                if (result)
                {
                    loginHandles.Add(type, new Dictionary<string, object>());
                    Debug.Log($"{type} SDK 完成初始化!");
                }
                else
                {
                    Debug.LogError($"{nameof(SDKManager)}: 请留意：{type} SDK 初始化未成功，请确认！！");
                }
            }
        }

        /// <summary>
        /// 同一个 NVR 只需要登录一次
        /// 必须先初始化 SDK 才能登录
        /// </summary>
        /// <param name="data"></param>
        public static object Login(NVRInformation data)
        {
            if (!GetLoginHandle(data, out object handle))
            {
                switch (data.type)
                {
                    case SDK.HK:
                        CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                        handle = CHCNetSDK.NET_DVR_Login_V30(data.Ip, (int)data.Port, data.userName, data.password, ref DeviceInfo);
                        if ((int)handle != -1)
                        {
                            //必须要使用 data.host 为key 此 host ip为局域网 ip
                            loginHandles[data.type][data.host] = handle;
                            Debug.Log($"{data.type} - {data.ActiveHost}监控登录成功：{handle}");
                        }
                        else
                        {
                            Debug.Log($"{data.type} - {data.ActiveHost}监控登录失败,ErrorCode = {CHCNetSDK.NET_DVR_GetLastError()}");
                        }
                        break;
                    case SDK.DH:
                    case SDK.YS:
                        break;
                }
            }
            else
            {
                Debug.Log($"{data.type} - {data.ActiveHost} 监控已经登录：{handle}");
            }
            return handle;
        }



        #region SDK status query
        /// <summary>
        /// 获取已经登录的 NVR 登录句柄/登录识别 ID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool GetLoginHandle(NVRInformation data, out object handle)
        {
            if (loginHandles.TryGetValue(data.type, out var handles))
            {
                if (handles.TryGetValue(data.host, out handle))
                {
                    return true;
                }
            }
            else
            {
                Debug.LogWarning($"{nameof(SDKManager)}: 获取句柄失败， {data.type} SDK 还未初始化。");
            }
            //如果查询不到登录状态，返回各个 SDK 未登录的默认值
            handle = GetDefaultHandle(data.type);
            return false;
        }




        public static object GetDefaultHandle(SDK type)
        {
            object handle;
            switch (type)
            {
                case SDK.DH:
                case SDK.YS:
                    handle = IntPtr.Zero;
                    break;
                case SDK.HK:
                default:
                    handle = -1;
                    break;
            }
            return handle;
        }

        public static bool IsInit(SDK type) => loginHandles.ContainsKey(type);
        public static bool IsLogin(NVRInformation nvrdata) => loginHandles.ContainsKey(nvrdata.type) && loginHandles[nvrdata.type].ContainsKey(nvrdata.host);
        #endregion

        #region Logout
        /// <summary>
        /// 登出同一个厂商的所有 设备（监控 或者 NVR）
        /// </summary>
        /// <param name="type">监控商</param>
        public static void Logout(SDK type)
        {
            if (loginHandles.TryGetValue(type, out var handles))
            {
                bool result = true;
                foreach (var item in handles)
                {
                    switch (type)
                    {
                        case SDK.HK:
                            var temp = CHCNetSDK.NET_DVR_Logout_V30((int)item.Value);
                            if (temp)
                            {
                                Debug.Log($"{nameof(SDKManager)}: {type} - {item.Key} 登出成功");
                            }
                            else
                            {
                                Debug.LogWarning($"{nameof(SDKManager)}: {type} - {item} 登出失败");
                            }
                            result &= temp;
                            break;
                        case SDK.DH:
                        case SDK.YS:
                            break;
                    }
                }
                if (result)
                {
                    handles.Clear(); //保留最外层的 key，意义在于可以标记 SDK 是否有被初始化，是否未被 Clean。
                }
            }
            else
            {
                Debug.LogWarning($"{nameof(SDKManager)}: {type} SDK 还未初始化！");
            }
        }
        /// <summary>
        /// 登出所有厂商的所有设备
        /// </summary>
        public static void LogoutAll()
        {
            foreach (SDK type in loginHandles.Keys)
            {
                Logout(type);
            }
            //loginHandles.Clear(); //这一句绝对不能写，因为最外层的 key 标记了 SDK Init 和 Clean 的状态 
        }
        /// <summary>
        /// 登出 NVR 或者监控设备
        /// </summary>
        /// <param name="data">指定设备信息</param>
        public static void Logout(NVRInformation data)
        {
            if (loginHandles.TryGetValue(data.type, out var handles))
            {
                if (handles.TryGetValue(data.host, out object handle))
                {
                    bool result = true;
                    switch (data.type)
                    {
                        case SDK.HK:
                            result = CHCNetSDK.NET_DVR_Logout_V30((int)handle);
                            break;
                        case SDK.DH:
                        case SDK.YS:
                            break;
                    }
                    if (!result)
                    {
                        Debug.LogWarning($"{nameof(SDKManager)}: {data.type} - {data.ActiveHost} 登出失败！ ");
                    }
                    else
                    {

                        Debug.Log($"{nameof(SDKManager)}: {data.type} - {data.ActiveHost}  登出成功！");
                        handles.Remove(data.host); //保留最外层的 key，意义在于可以标记 SDK 是否有被初始化，是否未被 Clean。
                    }
                }
                else
                {
                    Debug.LogWarning($"{nameof(SDKManager)}: {data.type} - {data.ActiveHost}  还未登录！");
                }
            }
            else
            {
                Debug.LogWarning($"{nameof(SDKManager)}: {data.type} SDK 还未初始化！");
            }
        }
        #endregion

        /// <summary>
        /// 程序退出时，退出登录并清除所有监控SDK
        /// </summary>
        public static void CleanUp()
        {
            LogoutAll();
            bool result = true;
            foreach (SDK type in loginHandles.Keys)
            {
                switch (type)
                {
                    case SDK.HK:
                        result = CHCNetSDK.NET_DVR_Cleanup();
                        Debug.Log($"海康 clean status = {result}");
                        break;
                    case SDK.DH:
                    case SDK.YS:

                        break;
                }
            }
            loginHandles.Clear();
        }

    }
}

