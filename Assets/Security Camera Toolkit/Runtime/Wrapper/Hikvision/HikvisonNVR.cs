using Hikvision;
using System.Threading.Tasks;
using UnityEngine;
namespace zFramework.Media
{
    public class HikvisonNVR : NVR
    {
        /// <summary>
        /// 由于SDK的初始化只需要有一次，故而使用静态属性
        /// <br>同时，也因为静态改属性不能收敛到基类了</br>
        /// </summary>
        public static bool IsSDKInit { get; private set; } = false;
        /// <summary>
        /// 断言 NVR 是否登录
        /// </summary>
        public override bool IsLogin => null != loginHandle && (int)loginHandle > -1;

        public HikvisonNVR(NVRInformation data) : base(data)
        {

        }

        /// <summary>
        /// 此方法需要在主线程使用，为啥？因为一般调用这个API是程序退出时，阻塞调用能避免程序退出异常
        /// </summary>
        public override void CleanUp()
        {
            // todo ： 不能这样写，要把 init 和 clean 分别写到首次 login 和 logout 最好用上 异步，避免卡顿
            Logout();
            if (IsSDKInit)
            {
                IsSDKInit = !CHCNetSDK.NET_DVR_Cleanup();
                if (IsSDKInit)
                {
                    Debug.Log($"{nameof(HikvisonNVR)}: 清理 SDK 出现异常");
                }
            }
        }

        public override void InitSDK()
        {
            if (!IsSDKInit)
            {
                CHCNetSDK.NET_DVR_SetConnectTime(2000, 3);
                CHCNetSDK.NET_DVR_SetReconnect(1000, 1);
                IsSDKInit = CHCNetSDK.NET_DVR_Init();
                if (!IsSDKInit)
                {
                    Debug.LogError($"{nameof(HikvisonNVR)}: SDK 初始化失败");
                }
            }
        }

        public override void Login()
        {
            if (!IsLogin)
            {
                _ = Task.Run(() =>
                {
                    CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                    loginHandle = CHCNetSDK.NET_DVR_Login_V30(data.Ip, (int)data.Port, data.userName, data.password, ref DeviceInfo);
                    if ((int)loginHandle != -1)
                    {
                        base.Login(); // 向挂载的监控发送 登录状态 , 注意，此动作在非Unity主线程中进行
                        Debug.Log($"{data.type} - {data.ActiveHost} NVR 登录成功：{loginHandle}");
                    }
                    else
                    {
                        Debug.Log($"{data.type} - {data.ActiveHost} NVR 登录失败,ErrorCode = {CHCNetSDK.NET_DVR_GetLastError()}");
                    }
                });
            }
            else
            {
                Debug.Log($"{data.type} - {data.ActiveHost} SDK 已经登录");
            }
        }

        public override void Logout()
        {
            base.Logout();
            if (IsLogin)
            {
                _ = Task.Run(() =>
                    {
                        var temp = CHCNetSDK.NET_DVR_Logout_V30((int)loginHandle);
                        if (temp)
                        {
                            Debug.Log($"{nameof(SDKManager)}: {data.ActiveHost} - {loginHandle} 登出成功");
                        }
                        else
                        {
                            Debug.LogWarning($"{nameof(SDKManager)}: {data.ActiveHost} - {loginHandle} 登出失败");
                        }
                    });
            }
        }
    }
}