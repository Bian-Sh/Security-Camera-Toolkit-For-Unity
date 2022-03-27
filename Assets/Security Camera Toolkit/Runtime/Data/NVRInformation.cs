// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System;
using UnityEngine;

namespace zFramework.Media
{
    [Serializable]
    public struct NVRInformation
    {
        /// <summary>
        /// NVR 主机地址，结构必须是 ip:port ,形如 127.0.0.1:8083 
        /// <para>这个 ip 是内网布线图上的 ip ，唯一 id 一般的存在</para>
        /// </summary>
        [Header("默认主机")]
        public string host;
        public SDKTYPE type;
        [Header("映射主机")]
        public string mapping; // 映射主机，外网访问
        [Header("启用映射"),Tooltip("复选框在映射主机存在的情况下激活")]
        public bool enableMapping; //映射使能，true 则使用映射主机访问监控，请注意如果多个 NVR  RTSP 端口为 554，只会有一个有效，请务必避免端口冲突
        [Header("NVR 账号")]
        public string userName;
        [Header("NVR 密码")]
        public string password;
        [Header("启用 NVR 配置"), Tooltip("复选框在默认主机存在的情况下激活")]
        public bool enable;
        [Header("描述")]
        public string description;
        public string Ip
        {
            get
            {
                var temp = enableMapping ? mapping : host;
                return temp.Trim().Split(':')[0];
            }
        }
        //端口
        public uint Port
        {
            get
            {
                var temp = enableMapping ? mapping : host;
                var arr = temp.Trim().Split(':');
                return Convert.ToUInt32(arr.Length==1?"80":arr[1]);
            }
        }

        public string ActiveHost => enableMapping ? mapping : host;
    }
}
