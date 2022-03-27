// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;
using UnityEditor;
using zFramework.Media;
using zFramework.Media.Internal;

[CustomEditor(typeof(SecurityCamera)), CanEditMultipleObjects]
public class SecurityCameraEditor : Editor
{
    SerializedProperty host;
    SerializedProperty sdk;
    private string error;
    private string tips = @"
1. NVR 配置丢失，点击 Load 可以重新生成配置
2. NVR 配置中无此主机，可以点击 Fixed 将主机写入配置中。
3. 正常情况下 load 和 Fixed 按钮为隐藏状态
";

    //由于Unity 出现了一个 Property 窗口，从该窗口切换换回来，OnEnable 不会重新执行，所以nvr数据要实时刷新
    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        host = host ?? serializedObject.FindProperty("host");
        EditorGUI.BeginChangeCheck();
        var itr = serializedObject.GetIterator();
        itr.NextVisible(true);// 跳过 脚本 窗口的绘制

        if (!string.IsNullOrEmpty(error))
        {
            EditorGUILayout.HelpBox(error, MessageType.Error);
        }
        while (itr.NextVisible(true))
        {
            if (itr.name == "host")
            {
                if (DrawHostAndRelatedProperty(host))
                {
                    // 构建资产并 ping 的动作会导致本 inspector host property 被 dispose ，所以直接跳出本轮绘制
                    return;
                }
            }
            else if (itr.name != "sdk")
            {
                EditorGUILayout.PropertyField(itr);
            }
        }

        host.isExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(host.isExpanded, "友情提示");
        EditorGUILayout.EndFoldoutHeaderGroup();
        if (host.isExpanded)
        {
            EditorGUILayout.HelpBox(tips, MessageType.None);
        }

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

    private bool DrawHostAndRelatedProperty(SerializedProperty host)
    {
        bool needreturn = false;
        error = string.Empty;
        using (EditorGUILayout.HorizontalScope scope = new EditorGUILayout.HorizontalScope())
        {
            EditorGUILayout.PropertyField(host);
            using (EditorGUILayout.VerticalScope scope_v = new EditorGUILayout.VerticalScope(GUILayout.Width(48)))
            {
                GUILayout.FlexibleSpace();
                if (NVRConfiguration.Instance)
                {
                    int index = NVRConfiguration.Instance.nvrs.FindIndex(V => V.host == host.stringValue);
                    if (index != -1)
                    {
                        var nvr = NVRConfiguration.Instance.nvrs[index];
                        sdk = sdk ?? serializedObject.FindProperty("sdk");
                        sdk.enumValueIndex = (int)nvr.type;
                        GUI.enabled = false;
                        EditorGUILayout.PropertyField(sdk, GUIContent.none, GUILayout.Width(48));
                        GUI.enabled = true;
                    }
                    else
                    {
                        error = @$" NVR 配置中不存在此主机，请修复!";
                        var wrap_cached = GUI.skin.button.wordWrap;
                        GUI.skin.button.wordWrap = true;
                        if (GUILayout.Button(new GUIContent(" Fixed ", "修复：点击将本数据写入 NVR 配置"), GUILayout.Width(0)))
                        {
                            AddHostBack(host.stringValue);
                            needreturn = true;
                        }
                        GUI.skin.button.wordWrap = wrap_cached;
                    }
                }
                else
                {
                    error = @$" NVR 配置文件不存在，请加载!";
                    var wrap_cached = GUI.skin.button.wordWrap;
                    GUI.skin.button.wordWrap = true;
                    if (GUILayout.Button(new GUIContent(" New ", "新建 NVR 配置文件"), GUILayout.Width(0)))
                    {
                        NVRConfiguration.Create();
                        if (NVRManager.Instance)
                        {
                            NVRManager.Instance.configuration = NVRConfiguration.Instance;
                            EditorUtility.SetDirty(NVRManager.Instance);
                        }
                        needreturn = true;
                    }
                    GUI.skin.button.wordWrap = wrap_cached;
                }
            }
        }
        return needreturn;
    }

    private void AddHostBack(string host)
    {
        var nvr = new NVRInformation
        {
            host = host,
            enable = true,
            type = (target as SecurityCamera).sdk,
            description = "此配置由机器生成，请补全信息！",
        };
        var config = NVRConfiguration.Instance;
        Undo.RecordObject(config, "BeforeHostAddBack");
        config.nvrs.Insert(0, nvr);
        EditorUtility.SetDirty(config);
        Selection.activeObject = config;
        Editor editor = default;
        CreateCachedEditor(config, typeof(NVRConfigurationEditor), ref editor);
        NVRConfigurationEditor nvr_editor = editor as NVRConfigurationEditor;
        var nvrs_prop = nvr_editor.serializedObject.FindProperty("nvrs");
        nvrs_prop.isExpanded = true;
        //把除了第一个以外的都折叠，方便用户关注核心问题
        for (int i = 0; i < config.nvrs.Count; i++)
        {
            var nvr_prop = nvrs_prop.GetArrayElementAtIndex(i);
            nvr_prop.isExpanded = i==0;
        }
        Debug.LogWarning($"成功将主机 <color=yellow> {nvr.host} </color> 到 NVR 配置第<color=yellow> 1</color> 项中，请务必补全其他信息！");
    }
}
