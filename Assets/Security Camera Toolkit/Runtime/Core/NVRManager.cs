// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;
using System.Reflection;
//todo: 类似 light Explorer 的场景 监控管理器，方便统一调整配置
//todo: videorenderer 测试 MaterialPropertyBlock ，

namespace zFramework.Media
{
    /// <summary>
    /// NVR 管理器
    /// <para>功能：SDK Init、SDK Clean up、登录、登出</para>
    /// <para>功能：SDK Init、SDK Clean up 自动处理</para>
    /// <para> 将 Execution Order 拉高，避免 <see cref="SecurityCamera"/> 比 <see cref="NVR "/>先初始化！</para>
    /// </summary>
    public class NVRManager : MonoBehaviour
    {
        #region Fields
        [SerializeField, Tooltip("是否自动加载 Json 文件，勾选则从磁盘加载并覆盖当前配置")]
        bool autoLoadJson = false;
        [SerializeField] SDKInitMode m_SDKInitMode = SDKInitMode.Awake;
        public NVRConfiguration configuration;
        /// <summary>
        /// 记录实例化出来的 NVR 
        /// <br>约定：字典的 key （<see cref="SDKTYPE"/>）参与断言 SDK 初始化状态</br>
        /// </summary>
        public Dictionary<SDKTYPE, List<NVR>> nvrs = new Dictionary<SDKTYPE, List<NVR>>();
        /// <summary>
        /// 将 SDK 类型与 脚本中的类型进行指定，实现自动实例化对应的类型
        /// </summary>
        [SerializeField]
        List<TypeMapping> mappings = new List<TypeMapping>();
        #endregion

        #region SDK Init
        void Start()
        {
            if (m_SDKInitMode == SDKInitMode.Start)
            {
                InitSDK();
            }
        }
        private void Awake()
        {
            //注册前先反注册，避免意外注册多次
            Application.wantsToQuit -= Application_wantsToQuit;
            Application.wantsToQuit += Application_wantsToQuit;
            EnsureInstanceMode();

            if (autoLoadJson)
            {
                configuration?.LoadNvrConfiguration();
            }

            if (m_SDKInitMode == SDKInitMode.Awake)
            {
                InitSDK();
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
                        var nvr = CreateNVR(item.type, item);
                        if (!nvrs.TryGetValue(item.type, out var nvr_arr))
                        {
                            //如果取不出 SDK type 对应的 NVR ，则说明需要初始化 SDK
                            nvr_arr = new List<NVR>();
                            nvrs[item.type] = nvr_arr;
                            nvr.InitSDK();
                            Debug.Log($"{nameof(NVRManager)}: 完成 {item.type} SDK 初始化");
                        }
                        nvr_arr.Add(nvr);
                    }
                }
            }
            else
            {
                Debug.LogError($"{nameof(NVRManager)}: {nameof(NVRConfiguration) }还未指定！");
            }
        }
        #endregion

        #region SDK  Clean up，will automatically cleanup when applicaiton wants to quit
        private bool Application_wantsToQuit()
        {
            if (Application.isEditor)
            {
                // 因为编辑器下忽略此事件的返回值，所以协程中的逻辑可能不能执行完毕，故而使用同步方式退出。
                var cameras = nvrs.SelectMany(v => v.Value).SelectMany(v => v.cameras);
                if (null != cameras)
                {
                    foreach (var item in cameras)
                    {
                        item.OnLogout();
                        Debug.Log($"{nameof(NVRManager)}: Camera Logout {item.host}-{item.channel}");
                    }
                }
                SDKClean();
            }
            else
            {
                //case 01: 如果 nvr 都没初始化，那就直接不卡退出
                //case 02:  如果 nvr 列表中存在 nvr 则需要先将 NVR 退出登录（同时退出监控播放）。
                if (nvrs.Count != 0 && null == clearopt)
                {
                    clearopt = StartCoroutine(CleanUpAsyncOperation());
                    return false;
                }
            }
            return true;
        }
        Coroutine clearopt = default;
        private IEnumerator CleanUpAsyncOperation()
        {
            //1. 退出在线的 NVR 
            var nvr_arr = nvrs.SelectMany(v => v.Value);
            var tasks = new List<Task>();
            foreach (var item in nvr_arr)
            {
                tasks.Add(item.LogoutAsync());
            }
            var task = Task.WhenAll(tasks);
            Debug.Log($"{nameof(NVRManager)}: 正在执行 NVR 登出....");
            while (!task.IsCompleted)
            {
                yield return 0;
            }
            Debug.Log($"{nameof(NVRManager)}: NVR 均已登出....");
            //2. Clean SDK 
            // NVR SDK 的 Clean up 动作只需要执行一次
            SDKClean();
            clearopt = null;
            //3. 真的退出
            Application.Quit();
        }

        private void SDKClean()
        {
            foreach (var item in nvrs)
            {
                if (item.Value.Count > 0)
                {
                    var nvr = item.Value[0];
                    if (null != nvr)
                    {
                        Debug.Log($"{nameof(NVRManager)}: 正在执行 {nvr.data.type} SDK Clean....");
                        nvr.CleanUp();
                    }
                }
            }
            nvrs.Clear();
            Debug.Log($"{nameof(NVRManager)}: SDK All Clean up");
        }
        #endregion

        #region Handle NVR Login/Logout
        /// <summary>
        /// 登录指定的 NVR 
        /// </summary>
        /// <param name="host">按用户指定主机名查询</param>
        public static async Task LoginAsync(string host)
        {
            if (!string.IsNullOrEmpty(host))
            {
                // 项目中用到的 NVR 屈指可数，Linq 闭着眼睛用
                var nvr = Instance.nvrs.SelectMany(v => v.Value)
                                                           .FirstOrDefault(v => v.data.host == host);
                await nvr?.LoginAsync();
            }
        }
        /// <summary>
        /// 登出指定的 NVR 
        /// </summary>
        /// <param name="host">按用户指定的主机查询</param>
        public static async Task LogoutAsync(string host)
        {
            if (!string.IsNullOrEmpty(host))
            {
                // 项目中用到的 NVR 屈指可数，Linq 闭着眼睛用
                var nvr = Instance.nvrs.SelectMany(v => v.Value)
                                                               .FirstOrDefault(v => v.data.host == host);
                await nvr?.LogoutAsync();
            }
        }
        /// <summary>
        /// 无差别登录所有 NVR 
        /// </summary>
        /// <returns></returns>
        public static async Task LoginAllAsync()
        {
            var nvr_arr = Instance.nvrs.SelectMany(v => v.Value);
            var tasks = new List<Task>();
            foreach (var item in nvr_arr)
            {
                tasks.Add(item.LoginAsync());
            }
            Debug.Log($"{nameof(NVRManager)}: 正在执行 NVR 登录....");
            await Task.WhenAll(tasks);
            Debug.Log($"{nameof(NVRManager)}:  所有 NVR 登录完成！");
        }

        /// <summary>
        /// 无差别登出所有 NVR 
        /// </summary>
        /// <returns></returns>
        public static async Task LogoutAllAsync()
        {
            var nvr_arr = Instance.nvrs.SelectMany(v => v.Value);
            var tasks = new List<Task>();
            foreach (var item in nvr_arr)
            {
                tasks.Add(item.LogoutAsync());
            }
            Debug.Log($"{nameof(NVRManager)}: 正在执行 NVR 登出....");
            await Task.WhenAll(tasks);
            Debug.Log($"{nameof(NVRManager)}:  所有 NVR 登出完成！");
        }
        #endregion

        #region Handle SecurityCamera Regiester

        /// <summary>
        /// 反注册监控摄像机
        /// </summary>
        /// <param name="camera"></param>
        internal static void DisconnectNVR(SecurityCamera camera)
        {
            if (Instance.nvrs.TryGetValue(camera.sdk, out var nvr_arr))
            {
                var host = camera.Host;
                var nvr = nvr_arr.Find(v => v.data.host == host);
                if (null != nvr)
                {
                    nvr.RemoveCamera(camera);
                    Debug.Log($"{nameof(NVRManager)}: NVR {host} 断开 SecurityCamera 【{camera.name} 】");
                }
                else
                {
                    Debug.Log($"{nameof(NVRManager)}:  没找到主机为 {host} 的 NVR 实例，请先初始化 NVR ！");
                }
            }
        }

        /// <summary>
        /// 注册监控摄像机
        /// </summary>
        /// <param name="camera"></param>
        internal static void ConnectNVR(SecurityCamera camera)
        {
            if (Instance.nvrs.TryGetValue(camera.sdk, out var nvr_arr))
            {
                var host = camera.Host;
                var nvr = nvr_arr.Find(v => v.data.host == host);
                if (null != nvr)
                {
                    nvr.AddCamera(camera);
                    Debug.Log(@$"{nameof(NVRManager)}: SecurityCamera 完成 NVR 挂载！更多↓ 
监控：      {camera.name}
主机：      {host}
sdktype：{camera.sdk}
");
                }
                else
                {
                    Debug.Log($"{nameof(NVRManager)}:  没找到主机为 {host} 的 NVR 实例，请先初始化 NVR ！");
                }
            }
        }
        #endregion

        #region Simple Singleton
        static NVRManager instance;
        public static NVRManager Instance
        {
            get
            {
                if (!instance)
                {
                    instance = FindObjectOfType<NVRManager>();
                }
                return instance;
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
        #endregion

        #region Instance Factory
        /// <summary>
        /// 类型映射，预设与不同监控厂商对应的 NVR 和 CameraService 
        /// </summary>
        [Serializable]
        class TypeMapping
        {
            public SDKTYPE sdk;
            [MonoScript]
            public string nvr;
            [MonoScript]
            public string camera;
            public string description;
        }

        /// <summary>
        /// 构建 <see cref="NVR"/> 实例
        /// </summary>
        /// <param name="sdk">指定厂商</param>
        /// <param name="info">指定 NVR 信息</param>
        /// <returns><see cref="NVR"/>实例</returns>
        public static NVR CreateNVR(SDKTYPE sdk, NVRInformation info)
        {
            NVR nvr = default;
            var map = Instance.mappings.Find(v => v.sdk == sdk);
            if (null != map && !string.IsNullOrEmpty(map.nvr))
            {
                nvr = Create<NVR>(map.nvr, info);
                Debug.Log(@$"{nameof(NVRManager)}: 实例化 NVR 完成! 更多 ↓
SDK：{sdk}
NVR：{nvr.GetType().Name}
host：{info.ActiveHost}
备注:   {(string.IsNullOrEmpty(info.description) ? "缺省" : info.description)}
");
            }
            else
            {
                Debug.LogError($"{nameof(NVRManager)}: 无法完成 NVR 实例化，厂商 {sdk} 的 NVR 类型未指定！ ");
            }
            return nvr;
        }

        /// <summary>
        /// 构建 <see cref="CameraService"/> 实例
        /// </summary>
        /// <param name="sdk">指定厂商</param>
        /// <param name="cam">指定 监控需要的 信息</param>
        /// <returns><see cref="CameraService"/>实例</returns>
        public static CameraService CreateCamera(SDKTYPE sdk, SecurityCamera cam)
        {
            CameraService service = default;
            var map = Instance.mappings.Find(v => v.sdk == sdk);
            if (null != map && !string.IsNullOrEmpty(map.camera))
            {
                service = Create<CameraService>(map.camera, cam);
                Debug.Log(@$"{nameof(NVRManager)}: 实例化 SecurityCameraService 完成! 更多 ↓
SDK：   {sdk}
通道：  {cam.channel}
流类型: {cam.steamType}
主机：  {cam.host}
");
            }
            else
            {
                Debug.LogError($"{nameof(NVRManager)}: 无法完成 NVR 实例化，厂商 {sdk} 的 NVR 类型未指定！ ");
            }
            return service;
        }

        static T Create<T>(string type, params object[] args) where T : class, new()
        {
            T instance = default;
            if (!string.IsNullOrEmpty(type))
            {
                type = type.Substring(0, type.IndexOf(','));
                Type t = Assembly.GetExecutingAssembly().GetType(type, true, true);
                if (null != t)
                {
                    instance = Activator.CreateInstance(t, args) as T;
                }
            }
            return instance;
        }
        #endregion

        #region Miscellaneous 杂项
        /// <summary>
        /// SDK 初始化时机
        /// </summary>
        enum SDKInitMode
        {
            None,
            Awake,
            Start
        }
#if UNITY_EDITOR
        private void Reset()
        {
            configuration = NVRConfiguration.Instance;
            if (!configuration)
            {
                Debug.Log($"{nameof(NVRManager)}: Create a new one");
                configuration = NVRConfiguration.Create();
            }
        }
#endif
        #endregion
    }
}