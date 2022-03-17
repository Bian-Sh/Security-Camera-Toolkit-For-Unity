using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using UnityEngine;

//仅处理打包完成后的文件夹海康 SDK 相关动态链文件转移工作
// This script
namespace zFramework.Media.Editor
{
    static class AssetsPostProcessing
    {
        [PostProcessBuild(1)]
        public static void Processing(BuildTarget target, string pathToBuiltProject)
        {
            var paths = AssetDatabase.FindAssets("HCNetSDKCom t:Folder");
            if (paths.Length == 0) return;
            if (paths.Length > 1) // 只允许存在一个 HCNetSDKCom 文件夹
            {
                UnityEngine.Debug.LogError($"{nameof(AssetsPostProcessing)}: Please make sure there has only one SDK Directory \''HCNetSDKCom\" in the project");
                return;
            }

            //Step 1 Collect all the dll file under ther hikvision folder  获取海康威视所有 Dll 文件列表
            var HC_SDK_DIR = new DirectoryInfo(AssetDatabase.GUIDToAssetPath(paths[0]));
            FileInfo[] core_dll = HC_SDK_DIR.GetFiles("*.dll", SearchOption.AllDirectories);

            //Step 2 Collect and put the dll files back into the "HCNetSDKCom" folder; 将 Unity 打包时弄混的Hikvision的dll文件再捋出来放回 “HCNetSDKCom”文件夹.
            string app_path = pathToBuiltProject.Substring(0, pathToBuiltProject.LastIndexOf("/"));
            string pluginPath = "Plugins" +
#if UNITY_2019_4_OR_NEWER
            "/x86_64/";
#endif
            string dstpath = Path.Combine(app_path, $"{Application.productName}_Data", pluginPath, "HCNetSDKCom");//拼接并创建 HCNetSDKCom 文件夹;
            if (!Directory.Exists(dstpath))
            {
                Directory.CreateDirectory(dstpath);
            }
            var dst_Dir_Info = new DirectoryInfo(dstpath);
            for (int i = 0; i < core_dll.Length; i++)
            {
                string srcfile = Path.Combine(dst_Dir_Info.Parent.FullName, core_dll[i].Name); //拼接Unity dll 文件混着放的路径
                string dstfile = Path.Combine(dstpath, core_dll[i].Name); // 拼接 dll 新路径 ;
                Directory.Move(srcfile, dstfile);//5. 转移文件
            }
        }
    }
}
