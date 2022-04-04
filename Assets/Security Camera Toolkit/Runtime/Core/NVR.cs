// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using zFramework.Media.Internal;

namespace zFramework.Media
{
    public class NVR
    {
        /// <summary>
        /// NVR 实例绑定的 信息
        /// </summary>
        public NVRInformation data;
        protected object loginHandle;
        public object LoginHandle => loginHandle;
        public virtual bool IsLogin { get; }
        /// <summary>
        /// NVR 下的所有监控
        /// </summary>
        public List<SecurityCamera> cameras;
        public NVR() { }
        public NVR(NVRInformation data)
        {
            this.data = data;
            cameras = new List<SecurityCamera>();
        }

        #region About NVR
        /// <summary>
        /// NVR 登录
        /// <para>执行登录逻辑之前通过<see cref="INVRStateHandler.OnLogin"/>向名下监控发送事件</para>
        /// </summary>
        public virtual async Task LoginAsync()
        {
            foreach (var item in cameras)
            {
                TaskSync.Post(() => item.OnLogin(loginHandle));
            }
            await QueryCameraStatusAsync(true);
        }

        // 这个查询动作的必要性在于：
        // 登录：登录发生在非主线程，TaskSync 投递的事件不是同步完成需要检测
        // 登出：理由同上，另外，需要 SecurtiyCamera 先都退出了再 退出NVR 
        /// <summary>
        /// 查询挂载到 NVR 的各个相机是否已经同步登录/登出句柄,并处理了各自的登录登出事宜
        /// </summary>
        /// <param name="loginstate">查询的状态</param>
        /// <returns></returns>
        async Task QueryCameraStatusAsync(bool loginstate)
        {
            await Task.Run(() =>
            {
                var waiting = true;
                do
                {
                    Thread.Sleep(30);//每次检查状态前先等几帧的感觉 ，一般情况下，一帧是 0.02f 
                    waiting = cameras.Any(v => v.IsLogin != loginstate);
                } while (waiting);
            });
        }




        /// <summary>
        /// NVR 登出
        /// <para>执行登出逻辑之前通过<see cref="INVRStateHandler.OnLogout"/>向名下监控发送事件</para>
        /// </summary>
        public virtual async Task LogoutAsync()
        {
            foreach (var item in cameras)
            {
                TaskSync.Post(() => item.OnLogout());
            }
            await QueryCameraStatusAsync(false);
        }
        #endregion
        #region About SDK
        /// <summary>
        /// 初始化 SDK 
        /// <br>基本上所有 SDK 的初始化速度都非常的快，所以直接主线程走起</br>
        /// </summary>
        public virtual bool InitSDK()
        {
            return false;
        }
        /// <summary>
        /// 清理 SDK 
        /// <br>CleanUp 应该只被安排在软件退出的那一刻，同步逻辑更简单，主线程走起</br>
        /// </summary>
        public virtual bool CleanUp()
        {
            return false;
        }
        #endregion
        #region About Camera 
        public void AddCamera(SecurityCamera camera)
        {
            if (!cameras.Contains(camera))
            {
                cameras.Add(camera);
                //首次注册 NVR ，同步 NVR 登录状态
                camera.OnLogin(loginHandle);
            }
        }
        public void RemoveCamera(SecurityCamera camera)
        {
            if (cameras.Contains(camera))
            {
                cameras.Remove(camera);
            }
        }
        #endregion

    }

}
