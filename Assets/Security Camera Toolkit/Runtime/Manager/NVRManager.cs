// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;
using zFramework.Media.Internal;
#if UNITY_EDITOR
#endif
namespace zFramework.Media
{
    /// <summary>
    /// NVR 管理器
    /// <para>功能：SDK 初始化、登录、登出、SDK 回收</para>
    /// </summary>

    public class NVRManager : MonoBehaviour
    {
        [SerializeField] SDKInitMode m_SDKInitMode = SDKInitMode.Awake;
        [Range(0.5f, 1.0f)]

        public NVRConfiguration configuration;


        //todo : 数据重复提醒，host 格式要对，复选框 要在指定了 host 后激活 、 Provider 可以下拉选择 nvr
        //todo: 类似 light Explorer 的场景 监控管理器，方便统一调整配置
        //todo: delayinputfiled  password filed
        //todo: videorenderer 测试 MaterialPropertyBlock ，
        //todo: 借鉴 ms-webrtc 的 逻辑应该是没用好，要处理，现在放着放着就延迟了
        void Start()
        {
            if (m_SDKInitMode == SDKInitMode.Start)
            {
                InitSDK();
            }
        }
        private void Awake()
        {
            EnsureInstanceMode();
            configuration?.LoadNvrConfiguration();
            if (m_SDKInitMode == SDKInitMode.Awake)
            {
                InitSDK();
            }
        }

        private void EnsureInstanceMode()
        {
            instance = this;
            //只能放在场景根节点
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
            // 如果二次实例化，则当即销毁
            if (gameObject != Instance.gameObject)
            {
                DestroyImmediate(gameObject);
            }
        }

        /// <summary>
        /// 初始化正在使用中的 SDK 
        /// </summary>
        private void InitSDK()
        {
            if (configuration)
            {
                foreach (var item in configuration.nvrs)
                {
                    if (item.enable)
                    {
                        SDKManager.InitSDK(item.type);
                    }
                }
            }
        }
        /// <summary>
        /// 清理 SDK 
        /// </summary>
        private void OnApplicationQuit()
        {
            // 先告知所有监控 NVR 要退出了
            foreach (var handles in cameras.Values)
            {
                foreach (var item in handles)
                {
                    item.OnLogout();
                }
                handles.Clear();
            }
            cameras.Clear();
            SDKManager.CleanUp();
        }


        /// <summary>
        /// 登录 NVR 
        /// <para>由于直接调用登录 API 多少会卡主线程，现在使用 <see cref="Task" />开线程登录</para>
        /// </summary>
        /// <param name="predicate">按用户指定的查询条件登录，如果未指定则全部登录</param>
        public static void Login(Predicate<NVRInformation> predicate = null)
        {
            predicate = predicate ?? (_ => true);
            var nvrs = Instance.configuration.nvrs.FindAll(predicate);
            // 由于 SDK 登录需要访问网络，会存在延迟，为避免卡主线程，此处使用 Task 
            _ = Task.Run(() =>
            {
                foreach (var item in nvrs)
                {
                    if (item.enable)
                    {
                        var handle = SDKManager.Login(item);
                        lock (cameras)
                        {
                            if (cameras.TryGetValue(item.host, out var handlers))
                            {
                                foreach (var handler in handlers)
                                {
                                    //由于现在在其他线程中，需要使用线程同步工具广播
                                    try
                                    {
                                        TaskSync.Post(() => handler.OnLogin(handle));
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.LogError($"{nameof(NVRManager)}: {item.host} OnLogin 访问异常 {e}");
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// 登出 NVR 
        /// <para>由于直接调用登出 API 多少会卡主线程，现在使用 <see cref="Task" />开线程登录</para>
        /// </summary>
        /// <param name="predicate">按用户指定的查询条件登出，如果未指定则全部登出</param>
        public static void Logout(Predicate<NVRInformation> predicate = null)
        {
            predicate = predicate ?? (_ => true);
            var nvrs = Instance.configuration.nvrs.FindAll(predicate);
            _ = Task.Run(() =>
            {
                foreach (var item in nvrs)
                {
                    if (item.enable)
                    {
                        lock (cameras)
                        {
                            if (cameras.TryGetValue(item.host, out var handlers))
                            {
                                foreach (var handler in handlers)
                                {
                                    //由于现在在其他线程中，需要使用线程同步工具广播
                                    try
                                    {
                                        TaskSync.Post(() => handler.OnLogout());
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.LogError($"{nameof(NVRManager)}: {item.host} OnLogout 访问异常 {e}");
                                    }
                                }
                            }
                        }
                        SDKManager.Logout(item); //先退出播放器再退出登录
                    }
                }
            });
        }

        /// <summary>
        /// 获取指定的 NVR 登录句柄
        /// </summary>
        /// <param name="predicate">断言</param>
        /// <remarks>断言建议使用 <see cref="NVRInformation.host"/> + <see cref="NVRInformation.type"/>的模式</remarks>
        /// <param name="handle">登录句柄</param>
        /// <returns>是否获取成功</returns>
        public static bool TryGetLoginHandle(Predicate<NVRInformation> predicate, out object handle)
        {
            if (null != predicate)
            {
                var info = Instance.configuration.nvrs.Find(predicate);
                if (!string.IsNullOrEmpty(info.host))
                {
                    return SDKManager.GetLoginHandle(info, out handle);
                }
                else
                {
                    Debug.LogError($"{nameof(TryGetLoginHandle)}: 未能找到满足筛选条件的主机，请无比确认！");
                }
            }
            else
            {
                Debug.LogError($"{nameof(TryGetLoginHandle)}: 必须指定一个断言");
            }
            handle = null;
            return false;
        }
        public static string[] GetEnabledHosts()
        {
            return Instance?.configuration.nvrs
                                            .Where(v => v.enable)
                                            .Select(v => v.host)
                                            .ToArray();
        }


        /// <summary>
        /// 反注册监控摄像机
        /// </summary>
        /// <param name="stateHandler"></param>
        internal static void UnRegister(INVRStateHandler stateHandler)
        {
            if (cameras.TryGetValue(stateHandler.Host, out var handlers))
            {
                handlers = handlers ?? new List<INVRStateHandler>();
                if (handlers.Contains(stateHandler))
                {
                    handlers.Remove(stateHandler);
                }
            }
        }

        /// <summary>
        /// 注册监控摄像机
        /// </summary>
        /// <param name="stateHandler"></param>
        internal static void Register(SDK sdk, INVRStateHandler stateHandler)
        {
            var host = stateHandler.Host;
            if (!cameras.TryGetValue(host, out var handlers))
            {
                handlers = new List<INVRStateHandler>();
                cameras[host] = handlers;
            }

            if (!handlers.Contains(stateHandler))
            {
                handlers.Add(stateHandler);
                // 首次注册需要反馈 登录句柄回去
                if (TryGetLoginHandle(info => info.host == host && info.type == sdk, out var loginHandle))
                {
                    stateHandler.OnLogin(loginHandle);
                }
            }
        }


        /// <summary>
        /// SDK 初始化时机
        /// </summary>
        enum SDKInitMode
        {
            None,
            Awake,
            Start
        }
        static NVRManager instance;
        static NVRManager Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<NVRManager>();
                }
                return instance;
            }
        }//单例
        static Dictionary<string, List<INVRStateHandler>> cameras = new Dictionary<string, List<INVRStateHandler>>();
        private void Reset()
        {
            configuration = NVRConfiguration.Instance;
            if (!configuration)
            {
                Debug.Log($"{nameof(NVRManager)}: Create a new one");
                configuration = NVRConfiguration.Create();
            }
        }
    }
}