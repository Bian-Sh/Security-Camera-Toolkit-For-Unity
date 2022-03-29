# Security-Camera-Toolkit-For-Unity

> 一个在 Unity 开发的应用中实现国内头部监控厂商监控播放的框架；
> 
> 可扩展，能轻松接入国内所有头部监控厂商的监控 SDK 
> 
> 请注意，此框架仅演示了海康的实时播放功能，但是，因为其他功能都围绕播放来的，所以在本框架 **一** 就是 **多**
> 
> 欢迎各位同仁通过推送 PR 的方式丰富本项目功能，比如 其他厂商SDK的接入， PTZ ，回放，查询，事件的接入等等...

## 动画演示

![](./docs/securityCamera.gif)

# 核心组件：

> 核心组件用于约定 NVR 监控框架的内部逻辑、依赖关系。具有完善的编辑器工作流。扩展其他厂商的 SDK 无需修改核心组件。

- ``NVRManager``：用于管理 NVR 登录、登出、SDK的初始化、Clean UP

- ``NVR`` ：所有 NVR 的基类

- ``NVRConfiguration``：用于存储项目中需要加载的 NVR 配置，``ScriptableObject`` 单例，一键生成。

- ``SecurityCamera`` : 所有厂商的监控的统一门面，用于配置 NVR 主机、通道 、主/辅流

- ``CameraService`` ：所有监控的基类，约定监控公共逻辑

- ``VideoRenderer``:视频渲染组件，用于将 YUV 视频数据转为 RGB 视频帧 

- ``WordMapping``: 框架内编辑器中使用的本地化**本地化** 模块，``ScriptableObject`` 单例，目前仅对 ``NVRInformation`` 进行了本地化处理，语言跟随系统语言变换

## 定制组件：

> 目前仅针对 海康 （Hikvision）实时播放做了定制，使用 async/await 语法糖实现了SDK 的异步登录登出操作，登录过程中拖拽滚动视图也能纵享新丝滑。
> 
> 如果想要定制其他监控厂商的 SDK ，可以以本人实现的 Hikvision 实时播放功能脚本为蓝本进行临摹（仅 2 个脚本）

- ``HikvisionNVR`` ：实现通过海康 SDK 进行 NVR 的登录、登出、SDK 初始化和回收。

- ``HKService``: 继承 CameraService，实现通过海康 SDK 进行实时视频的低延迟播放，当然，如果想要 PTZ 吖，回放吖，文件查询吖，可以统统写这里，但此时门面脚本 ``SecurityCamera`` 功能也要扩充了，这点能理解的，对吧。

## 编辑器工作流：

 ![](./docs/workflow.gif)

**Tips: 展开可见图文详情**
<details>
<summary>1. 通过 NVR 配置面板配置你的 NVR 信息</summary>

 > 用于记录 NVR 配置信息，实现按配置启用 NVR，支持多个 NVR 同时工作 ，支持公网映射（反向代理需关注 554 端口），因为可能存在一众 NVR 吵着闹着要代理同一个 554 端口的情况
 
 > 支持配置序列化、反序列化，以 json 格式保存本地，可动态修改不惧 NVR 变动。
 
 > 使用 ScriptableObject 单例，使用时自动生成，用户无需关注其生命周期

 ![](./docs/NVRConfiguration.png)

</details>

<details>
<summary>2. 使用 NVR 管理器管理各异的厂商类型的 NVR </summary>

 > 用于挂载 NVR 配置，完善的 NVR 配置丢失警示+找回功能；
 
 > 管理 NVR 的公共行为,管理 SDK 的初始化和回收
  
 > 提供 Mappings ，籍此实现在保持核心组件不修改的情况下支持多监控厂商 SDK 同时工作在一个项目中。
  
正常|NVR 配置丢失
 |-|-|
 ![](./docs/NVRManager.png)|![](./docs/NVRManager_Failure.png)

</details>

<details>
<summary>3. 使用 Security Camera 管理各异厂商的推流逻辑（只有推流逻辑，但你可以写更多功能） </summary>

 > 作为门面一样的存在，不管是哪一个厂商的监控，都是使用它对外，对内按 NVRManager Mappings 的配置实例化指定的 ``CameraService`` 实现厂商差异化交互逻辑
 
 > 提供了与 ``NVRConfiguration`` 联动的 host 下拉选择，无需用户输入；同时提供了与 ``NVRConfiguration`` 数据不匹配时的编辑器工作流，数据有效性一目了然，更可快速修正。
 
> todo: 想要 通过 ``RawImage`` 大小自动判断使用**主流**还是**辅流**，用户可自行设置转换阈值 宽高同时低于这个阈值就会切换流类型
 
正常|NVR 配置指定数据丢失|NVR 配置丢失
 |-|-|-|
 ![](./docs/SecurityCamera_normal.png)|![](./docs/SecurityCamera_nohost.png)|![](./docs/SecurityCamera_noconfig.png)

</details>

<details>
<summary>4. 通过 Video Renderer 实现 YUV 推流数据的渲染</summary>

 > 视频渲染组件，实现了 YUV 数据到 RGB 数据的转换；使用 unsafe 数据拷贝，速度更快；按渲染能力拷贝，绝对不做多余的数据对拷操作； 可调整绘制帧率，性能一手掌握；
 
 > 提供帧率统计：推流、渲染、丢弃帧率一目了然，（考虑性能问题，推荐不统计，推荐不展开调试面板）
 
 > 解决了大家可能遇到的监控放在 ScrollRect 中画面不动的问题，这个坑是 Mask 的锅，你只需要使用 RawImage.materialForRendering 就好啦。
  
 ![](./docs/VideoRenderer.png)
 
 如果你发现画面颠倒了，别慌，找到 YUV 材质球按图示勾选/反选 即可找回正确的画面，前提是调整发生在 ``SecurtiyCamera.Start`` 方法调用前
 
  ![](./docs/PictureFlip.png)
 
</details>
 
 <details>
<summary>5. 通过 WordMapping 实现 本框架编辑器本地化</summary>

 > 使用 ``ScriptableObject`` 单例，使用 subassets 的理念（Subassets对这种固化的框架友好，协同作业避免使用 subasset 方式整合配置文件）

 > 可以为每个核心组件单独配一个``MapCollections``本地化配置表  实现本地化信息的合理分组策略和访问策略

 > 目前仅把这个功能模块接入到了 ``NVRInformationPropertyDrawer`` 中，为啥，因为写到这个 Drawer 的时候来的跳出来的想法吖。

 > 效果在上面那个长长的 GIF 中可以看到，或者直接 Clone 这个仓库，编辑器打开就能看
 
 ![](./docs/Localization.png)
 
</details>
 
 
## Reference
[我的简书博客](https://www.jianshu.com/p/e8e906c6700c)

## 免责声明：

1. 这个项目目前接的是 海康的 SDK ，如需使用他们的 SDK，请阅读他们的许可说明并在其许可范围内作业。
2. 本仓库仅供交流，不对用户任何操作负责。
3. TO Hikvision：如果侵权，请邮件：bshsf@qq.com ,我会剔除你们的 SDK 动态链接库
. 

