using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using zFramework.Media;
using System.Linq;
using System;

[CustomEditor(typeof(SecurityCamera)), CanEditMultipleObjects]
public class SecurityCameraEditor : Editor
{
    string defaultitem = "NVR 主机未配置";
    SerializedProperty host;
    SerializedProperty sdk;
    private void OnEnable()
    {
    }

    private bool GetNVR(SerializedProperty host, out string[] hosts)
    {
        hosts = default;
        var isSucess = true;
        if (NVRConfiguration.Instance)
        {
            hosts = NVRConfiguration.Instance.nvrs.Where(v => !string.IsNullOrEmpty(v.host))
                                                                                           .Select(v => v.host)
                                                                                           .ToArray();
        }
        if (null == hosts || hosts.Length == 0)
        {
            hosts = new string[] { defaultitem };
            isSucess = false;
        }
        if (string.IsNullOrEmpty(host.stringValue))
        {
            host.stringValue = hosts[0];
        }
        return isSucess;
    }

    //由于Unity 出现了一个 Property 窗口，从该窗口切换换回来，OnEnable 不会重新执行，所以nvr数据要实时刷新
    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        host = host ?? serializedObject.FindProperty("host");
        var itr = serializedObject.GetIterator();
        while (null != itr && itr.NextVisible(true))
        {
            GUI.enabled = itr.name != "m_Script" && itr.name != "sdk";
            EditorGUI.BeginChangeCheck();
            if (itr.name == "host")
            {
                if (DrawHostProperty(host))
                {
                    break;
                }
            }
            else
            {
                EditorGUILayout.PropertyField(itr);
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
            GUI.enabled = true;
        }

    }

    private bool DrawHostProperty(SerializedProperty host)
    {
        bool needbreak = false;
        using (EditorGUILayout.HorizontalScope scope = new EditorGUILayout.HorizontalScope())
        {
            var state = GetNVR(host, out var arr);
            // 请留意：
            // 如果你的 NVR 配置中原先的数据不见了，SecurityCamera 中的host 信息会重置为第一个。
            // 所以 NVR 配置最好只做新增，不做删减
            var index = Mathf.Max(0, Array.FindIndex(arr, v => v == host.stringValue));
            index = EditorGUILayout.Popup(host.displayName, index, arr);
            //只有获取到正确的 host 才会赋值
            if (state)
            {
                host.stringValue = arr[index];
                SetSDKType(arr[index]);
            }
            else
            {
                GUI.skin.button.wordWrap = true;
                if (GUILayout.Button(new GUIContent(" Ping ", "Ping NVR配置文件,不存在则新建"), GUILayout.Width(0)))
                {
                    NVRConfiguration.Create();
                    needbreak = true;
                }
            }
            #region 不处理多选时值不一样的问题，费脑子，反正能用
            /*
            if (targets.Length > 1)
            {
                var diffvalue = targets.Cast<SecurityCamera>()
                                                            .Select(v => v.host)
                                                            .Distinct()
                                                            .Count();
                Debug.Log($"{nameof(SecurityCameraEditor)}: diffvalue count {diffvalue}");
                if (diffvalue!=1)//说明存在不同的值
                {

                }
            }
             */
            #endregion
        }
        return needbreak;
    }

    private void SetSDKType(string host)
    {
        if (host != defaultitem)
        {
            var nvr = NVRConfiguration.Instance.nvrs.Find(V => V.host == host);
            sdk = sdk ?? serializedObject.FindProperty("sdk");
            sdk.enumValueIndex = (int)nvr.type;
        }
    }
}
