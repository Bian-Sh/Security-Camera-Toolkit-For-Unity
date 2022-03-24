// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEditor;
using UnityEngine;
using zFramework.Media;
using static UnityEditor.EditorGUI;

[CustomEditor(typeof(NVRConfiguration))]
public class NVRConfigurationEditor : Editor
{
    NVRConfiguration manager;
    SerializedProperty list;
    GUIStyle title_style;
    private void OnEnable()
    {
        manager = target as NVRConfiguration;
    }
    public override void OnInspectorGUI()
    {
        title_style = title_style ?? new GUIStyle("box")
        {
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
            fontSize = 42,
            stretchWidth = true
        };
        EditorGUILayout.LabelField("NVR 配置面板", title_style);
        using (EditorGUILayout.VerticalScope scope = new EditorGUILayout.VerticalScope("box"))
        {
            indentLevel++;
            DrawList();
            indentLevel--;
            DrawConfigurationHandler();
        }
        EditorGUILayout.HelpBox(msg, MessageType.Info);
    }

    public void DrawList()
    {
        list = list ?? serializedObject.FindProperty("nvrs");
        serializedObject.UpdateIfRequiredOrScript();
        BeginChangeCheck();
        EditorGUILayout.PropertyField(list);
        if (EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            Repaint();
        }
    }

    public void DrawConfigurationHandler()
    {
        EditorGUILayout.BeginHorizontal();
        var fileExist = manager.ExistConfiguration();
        using (DisabledScope scope = new DisabledScope(!fileExist))
        {
            var tooltip = fileExist ? "加载 json 配置数据" : "配置还未保存过";
            if (GUILayout.Button(new GUIContent("加载配置", tooltip)))
            {
                Undo.RecordObject(manager, $"CaptureBeforeLoadJson{Time.frameCount}");
                manager.LoadNvrConfiguration();
            }
        }
        if (GUILayout.Button(new GUIContent("保存配置", "覆盖操作不可逆")))
        {
            if (fileExist)
            {
                //复用 bool fileExist
                fileExist = EditorUtility.DisplayDialog("NVR Configuration", "配置已存在，确认覆盖？", "确定", "取消");
            }
            if (fileExist)
            {
                manager.SaveNvrConfiguration();
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    string msg = @"约定：
1. NVR 配置最好只做新增，不做删减，否则 SecurityCamera.host 会被重置
2. NVR 配置文件全局只有一份(单例)
";
}

