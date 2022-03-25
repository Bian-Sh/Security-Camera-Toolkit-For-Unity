// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
namespace zFramework.Media
{
    /// <summary>
    /// 监控信息
    /// </summary>
public struct CameraInfomation
    {
        //这个监控所属的 NVR 
        public string host;
        // 指向 NVR 中的通道，海康不接 NVR 也行 channel 默认为 1 
        // 注意监控的 通道取值范围会因各个厂商而异
        public int channel;
        public STREAM steamType;
    }
}
