﻿// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;

namespace zFramework.Media
{
    public class SecurityCamera : MonoBehaviour, INVRStateHandler
    {
        [Header("请指定 NVR 主机地址:")]
        public string host;
        [Header("请指定监控商:")]
        public SDK sdk;
        [Header("请指定 NVR 通道:")]
        public int channel;
        public STREAM steam_Type = STREAM.MAIN;
        public VideoRenderer monitor;
        CameraService player = null;
        public string Host { get => host; }


        private void Start() => SetupPlayer();

        public void SetupPlayer()
        {
            var info = new CameraInfomation
            {
                channel = this.channel,
                host = this.host,
                steamType = this.steam_Type
            };
            switch (sdk)
            {
                case SDK.HK:
                    player = new HKCameraPlayer(info);
                    break;
                case SDK.YS:
                    break;
                case SDK.DH:
                    break;
            }
            NVRManager.Register(sdk, this);
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
            Stop();
            NVRManager.UnRegister(this);
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
        }
        #endregion
    }
}