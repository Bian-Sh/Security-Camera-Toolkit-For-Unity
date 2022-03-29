// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System;
namespace zFramework.Media
{
    [Serializable]
    public struct NVRInformation
    {
        /// <summary>
        /// NVR 主机地址，结构必须是 ip:port ,形如 127.0.0.1:8083 
        /// <para>这个 ip 是内网布线图上的 ip ，唯一 id 一般的存在</para>
        /// </summary>
        public string host;
        public SDKTYPE type;
        public string mapping; // 映射主机，外网访问
        public bool enableMapping; //映射使能，true 则使用映射主机访问监控，请注意如果多个 NVR  RTSP 端口为 554，只会有一个有效，请务必避免端口冲突
        public string userName;
        public string password;
        public bool enable;
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
