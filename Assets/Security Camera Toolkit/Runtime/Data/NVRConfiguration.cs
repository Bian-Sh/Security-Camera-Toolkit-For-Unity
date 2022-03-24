// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace zFramework.Media
{
    public class NVRConfiguration : ScriptableObject
    {
        const string soPath = "Security Camera Toolkit/Generated"; //存放 NVRConfiguration 实例
        public List<NVRInformation> nvrs = new List<NVRInformation>();

        #region Single Instance / 单例
        static NVRConfiguration _instance;
        public static NVRConfiguration Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = Load();
                }
                return _instance;
            }
        }
        private static NVRConfiguration Load()
        {
            var file = Path.Combine("Assets", soPath, $"{nameof(NVRConfiguration)}.asset");
            var so = AssetDatabase.LoadMainAssetAtPath(file);
            return so as NVRConfiguration;
        }
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

        #region 数据校验
        private void OnValidate()
        {
            for (int i = 0; i < nvrs.Count; i++)
            {
                var nvr = nvrs[i];
                if (!IsHostMatched(nvr.mapping) && nvr.enableMapping)
                {
                    nvr.enableMapping = false;
                    nvrs[i] = nvr;
                    Debug.LogError($"{nameof(NVRManager)}: 启用失败，映射主机非法，请检查！");
                }
                if (!IsHostMatched(nvr.host) && nvr.enable)
                {
                    nvr.enable = false;
                    nvrs[i] = nvr;
                    Debug.LogError($"{nameof(NVRManager)}: 启用失败，默认主机非法，请检查！");
                }
            }
        }
        /// <summary>
        /// 用于校验 IP:Port 的正则
        /// </summary>

        string pattern_ip = @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";
        string pattern_port = @"^((6553[0-5])|(655[0-2][0-9])|(65[0-4][0-9]{2})|(6[0-4][0-9]{3})|([1-5][0-9]{4})|([0-5]{0,5})|([0-9]{1,4}))$";
        private bool IsHostMatched(string host)
        {
            if (!host.EndsWith(":"))
            {
                var arr = host.Trim().Split(':');
                var ip = arr[0];
                var port = arr.Length == 1 ? "80" : arr[1];
                var ipMatch = Regex.IsMatch(ip, pattern_ip);
                var portMatch = Regex.IsMatch(port, pattern_port);
                return ipMatch && portMatch;
            }
            return false;
        }


        #endregion
    }
}