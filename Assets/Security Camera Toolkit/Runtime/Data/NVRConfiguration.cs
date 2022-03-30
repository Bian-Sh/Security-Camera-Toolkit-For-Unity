// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace zFramework.Media
{
    // TODO : 不允许输入相同的主机，需要在 inspector 上标识出来
    public class NVRConfiguration : ScriptableObject
    {
        const string soPath = "Security Camera Toolkit/Generated"; //存放 NVRConfiguration 实例
        public List<NVRInformation> nvrs = new List<NVRInformation>();

        #region Single Instance / 单例
        static NVRConfiguration _instance;
        public static NVRConfiguration Instance => Load();
        private static NVRConfiguration Load()
        {
#if UNITY_EDITOR
            if (!_instance)
            {
                var file = Path.Combine("Assets", soPath, $"{nameof(NVRConfiguration)}.asset");
                _instance = AssetDatabase.LoadMainAssetAtPath(file) as NVRConfiguration;
            }
#endif
            return _instance;
        }
#if UNITY_EDITOR
        public static NVRConfiguration Create()
        {
            if (!Instance)
            {
                var dir = Path.Combine(Application.dataPath, soPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    AssetDatabase.Refresh();
                }
                var file = Path.Combine("Assets", soPath, $"{nameof(NVRConfiguration)}.asset");
                var asset = CreateInstance<NVRConfiguration>();
                AssetDatabase.CreateAsset(asset, file);
                AssetDatabase.Refresh();
            }
            EditorGUIUtility.PingObject(Instance);
            return Instance;
        }
#endif

        #endregion

        #region NVR 数据本地化
        const string jsonName = "NvrConfiguration.json";
        string jsonPath = Path.Combine(Application.streamingAssetsPath, "Configurations");

        public bool ExistConfiguration() => File.Exists(Path.Combine(jsonPath, jsonName));
        //通过 本地json 获取 NVR 配置，方便动态修改 NVR 配置信息

        /// <summary>
        /// 将配置保存为 json
        /// </summary>
        public void SaveNvrConfiguration()
        {
            if (!Directory.Exists(jsonPath))
            {
                Directory.CreateDirectory(jsonPath);
            }
            var info = JsonUtility.ToJson(new Wrapper(nvrs), true);
            var file = Path.Combine(jsonPath, jsonName);
            File.WriteAllText(file, info, Encoding.UTF8);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
            file = FileUtil.GetProjectRelativePath(file);
            var obj = AssetDatabase.LoadMainAssetAtPath(file);
            EditorGUIUtility.PingObject(obj);
#endif
        }
        /// <summary>
        /// 从 本地 JSON 加载 NVR 配置
        /// </summary>
        public void LoadNvrConfiguration()
        {
            var file = Path.Combine(jsonPath, jsonName);
            if (File.Exists(file))
            {
                var info = File.ReadAllText(file);
                var obj = JsonUtility.FromJson<Wrapper>(info);
                if (null != obj)
                {
                    nvrs = obj.arr;
#if UNITY_EDITOR
                    if (!Application.isPlaying)
                    {
                        EditorUtility.SetDirty(this);
                    }
#endif
                }
            }
            else
            {
                Debug.LogWarning($"{nameof(NVRManager)}:不存在 json 配置文件 ，Path 见 ↓ \n{jsonPath} ");
            }
        }

        [Serializable]
        class Wrapper
        {
            public List<NVRInformation> arr;
            public Wrapper(List<NVRInformation> arr)
            {
                this.arr = arr;
            }
        }

        #endregion
        #region Miscellaneous 杂项
        public static string[] GetNVRHosts()
        {
            string[] arr = default;
            if (Instance)
            {
                arr = Instance.nvrs.Where(v => !string.IsNullOrEmpty(v.host))
                    .Select(v => v.host)
                    .ToArray();
            }
            return arr;
        }
        #endregion
    }
}