// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    using UnityEngine;
    using static NVRManager;
    public class SecurityCamera : MonoBehaviour, INVRStateHandler
    {
        [Header("NVR 主机"), StringPopup(typeof(NVRConfiguration), "GetNVRHosts", "NVR 未配置")]
        public string host;
        public SDKTYPE sdk;
        // 指向 NVR 中的通道，海康不接 NVR 也行 channel 默认为 1 
        // 注意监控的 通道取值范围会因各个厂商而异
        [Header("NVR 通道:")]
        public int channel;
        [Header("主/辅 流:")]
        public STREAM steamType = STREAM.MAIN;

        public VideoRenderer monitor;
        CameraService player = null;
        public string Host { get => host; }
        public bool IsLogin { get => null != player && player.HasLogin; }


        private void Start() => SetupPlayer();

        public void SetupPlayer()
        {
            player = CreateCamera(sdk, this);
            ConnectNVR(this);
        }

        //实时
        public void PlayReal()
        {
            if (!player.IsRealPlaying)
            {
                monitor.StartRendering(player);
                player.PlayReal();
            }
        }
        //暂停
        public void Pause()
        {
            player.Pause();
            monitor?.PauseRendering();
        }
        //停止
        public void Stop()
        {
            monitor?.StopRendering();
            player?.StopPlay();
        }
        //恢复
        public void Resume()
        {
            player.Resume();
        }

        private void OnDestroy()
        {
            // 编辑器下 Security Camera 有几率退出比 NVRManager 要早，所以先 try 为敬
            // 实际开发中，记得在推出前需要主动销毁监控
            try
            {
                Stop();
                DisconnectNVR(this);
            }
            catch (System.Exception e)
            {
                Debug.Log($"{nameof(SecurityCamera)}: {e}");
            }
        }

        //组件校验
        private void OnValidate()
        {
            if (!monitor)
            {
                monitor = GetComponentInChildren<VideoRenderer>();
            }
            if (!monitor)
            {
                Debug.LogWarning($"{nameof(SecurityCamera)}: 请挂载 VideoRenderer ！");
            }
        }

        #region NVR State Callbacks
        public void OnLogin(object loginHandle)
        {
            player?.SetLoginHandle(loginHandle);
        }

        public void OnLogout()
        {
            monitor?.StopRendering();
            player?.StopPlay();
            player?.SetLoginHandle(null);
        }
        #endregion
    }
}
