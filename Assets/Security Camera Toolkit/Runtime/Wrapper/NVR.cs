using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zFramework.Media.Internal;

namespace zFramework.Media
{
    public abstract class NVR : INVRBehaviours
    {
        /// <summary>
        /// NVR 实例绑定的 信息
        /// </summary>
        public NVRInformation data;
        protected object loginHandle;
        public abstract bool IsLogin{get;}
        /// <summary>
        /// NVR 下的所有监控
        /// </summary>
        public List<SecurityCamera> cameras;
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
        public virtual void Login()
        {
            foreach (var item in cameras)
            {
                TaskSync.Post(() => item.OnLogin(loginHandle));
            }
        }

        /// <summary>
        /// NVR 登出
        /// <para>执行登出逻辑之前通过<see cref="INVRStateHandler.OnLogout"/>向名下监控发送事件</para>
        /// </summary>
        public virtual void Logout()
        {
            foreach (var item in cameras)
            {
                TaskSync.Post(() => item.OnLogout());
            }
        }
        #endregion
        #region About SDK
        /// <summary>
        /// 初始化 SDK 
        /// </summary>
        public abstract void InitSDK();
        /// <summary>
        /// 清理 SDK 
        /// </summary>
        public abstract void CleanUp();
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
