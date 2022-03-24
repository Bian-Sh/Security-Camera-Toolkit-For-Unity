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
        const string soPath = "Security Camera Toolkit/Generated"; //��� NVRConfiguration ʵ��
        public List<NVRInformation> nvrs = new List<NVRInformation>();

        #region Single Instance / ����
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


        #region NVR ���ݱ��ػ�
        const string jsonName = "NvrConfiguration.json";
        string jsonPath = Path.Combine(Application.streamingAssetsPath, "Configurations");

        public bool ExistConfiguration() => File.Exists(Path.Combine(jsonPath, jsonName));
        //ͨ�� ����json ��ȡ NVR ���ã����㶯̬�޸� NVR ������Ϣ

        /// <summary>
        /// �����ñ���Ϊ json
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
        /// �� ���� JSON ���� NVR ����
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
                Debug.LogWarning($"{nameof(NVRManager)}:������ json �����ļ� ��Path �� �� \n{jsonPath} ");
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

        #region ����У��
        private void OnValidate()
        {
            for (int i = 0; i < nvrs.Count; i++)
            {
                var nvr = nvrs[i];
                if (!IsHostMatched(nvr.mapping) && nvr.enableMapping)
                {
                    nvr.enableMapping = false;
                    nvrs[i] = nvr;
                    Debug.LogError($"{nameof(NVRManager)}: ����ʧ�ܣ�ӳ�������Ƿ������飡");
                }
                if (!IsHostMatched(nvr.host) && nvr.enable)
                {
                    nvr.enable = false;
                    nvrs[i] = nvr;
                    Debug.LogError($"{nameof(NVRManager)}: ����ʧ�ܣ�Ĭ�������Ƿ������飡");
                }
            }
        }
        /// <summary>
        /// ����У�� IP:Port ������
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