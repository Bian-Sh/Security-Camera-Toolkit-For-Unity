// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    using UnityEngine;
    using static NVRManager;
    public class SecurityCamera : MonoBehaviour, INVRStateHandler
    {
        [Header("请指定 NVR 主机地址:")]
        public string host;
        public SDKTYPE sdk;
        [Header("请指定 NVR 通道:")]
        public int channel;
        public STREAM steam_Type = STREAM.MAIN;

        public VideoRenderer monitor;
        CameraService player = null;
        public string Host { get => host; }
        public bool IsLogin { get => null != player && player.HasLogin; }


        private void Start() => SetupPlayer();

        public void SetupPlayer()
        {
            var info = new CameraInfomation
            {
                channel = this.channel,
                host = this.host,
                steamType = this.steam_Type,
            };
            player = CreateCamService(sdk, info);
            ConnectNVR(this);
        }

        //实时
        public void PlayReal()
        {
            monitor.StartRendering(player);
            player.PlayReal();
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
            monitor?.StopRendering(player);
            player?.StopPlay();
        }
        //恢复
        public void Resume()
        {
            player.Resume();
        }

        private void OnDestroy()
        {
            // 编辑器下 Security Camera 退出比 NVRManager 要早，所以先 try 为敬
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
            monitor.StopRendering(player);
            player?.StopPlay();
            player?.SetLoginHandle(null);
        }
        #endregion
    }
}
