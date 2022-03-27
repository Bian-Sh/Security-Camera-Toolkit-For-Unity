# Security-Camera-Toolkit-For-Unity

> 一个在 Unity 中播放国内实时监控的框架 ，A toolkit for play security camera in unity made application

# 动画演示

![](./docs/securityCamera.gif)

# 核心组件：

> 核心组件用于约定 NVR 监控框架的内部逻辑、依赖关系。具有完善的编辑器工作流。扩展其他厂商的 SDK 无需修改核心组件。

- NVRManager：用于管理 NVR 登录、登出、SDK的初始化、Clean UP

- NVR ：所有 NVR 的基类

- NVRConfiguration：用于存储项目中需要加载的 NVR 配置

- SecurityCamera : 所有厂商的监控的统一门面，用于配置 NVR 主机、通道 

- CameraService ：所有监控的基类，约定监控公共逻辑

- VideoRenderer：视频渲染组件，用于将 YUV 视频数据转为 RGB 视频帧

# 定制组件：

> 目前仅针对 海康 （Hikvision）实时播放做了定制，使用 async/await 语法糖实现了SDK 的异步登录登出操作，绝不会出现卡 Unity 的现象。
> 
> 如果想要定制其他监控厂商的 SDK ，可以以本人实现的 Hikvision 实时播放功能脚本为蓝本进行临摹（仅 2 个脚本）

- HikvisionNVR ：实现通过海康 SDK 进行 NVR 的登录、登出、SDK 初始化和回收。

- HKService： 继承 CameraService，实现通过海康 SDK 进行实时视频的低延迟播放。

# 编辑器工作流：

<details>
<summary>NVR 配置面板</summary>

<img src="./docs/NVRConfiguration.png" title="" alt="" data-align="center">

  **功能说明：**

* 支持局域网网段的主机（默认）
- 支持使用反向代理映射出来的公网 NVR （请留意 RTSP 554 端口占用问题）

- 支持随意搭配 NVR 配置的启用、闲置。

- 支持将数据序列化到本地 json 文件

- 支持从本地 json 文件加载 NVR 配置，不惧主机变动
  
  
  
  </details>





但，播放功能实现了，其他功能还有啥要攻克的呢，监控可都围绕播放来的呢？

## 免责声明：

这个项目目前接的是 海康的 SDK ，如需使用请阅读他们的许可说明，本仓库仅供交流，不对用户任何操作负责。
