// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using UnityEditor;
using UnityEngine;
using zFramework.Media;

[CustomEditor(typeof(NVRManager))]
public class NVRManagerEditor : Editor
{
    SerializedProperty config;
    NVRConfigurationEditor editor;
    const string ConfigName = "configuration";

    private void OnEnable()
    {
        config = serializedObject.FindProperty(ConfigName);
        LoadNVRConfiguration();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();
        var idt = serializedObject.GetIterator();
        while (idt.NextVisible(true))
        {
            if (idt.name == ConfigName)
            {
                DrawNVRConfigurationNested();
            }
            else
            {
                GUI.enabled = idt.name != "m_Script";
                EditorGUILayout.PropertyField(idt);
                GUI.enabled = true;
            }
        }
        if (!config.objectReferenceValue)
        {
            EditorGUILayout.HelpBox("请使用右侧 ”Load“ 按钮添加 NVR Configuration 实例", MessageType.Error);
        }
        if (serializedObject.hasModifiedProperties)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void DrawNVRConfigurationNested()
    {
        using (EditorGUILayout.VerticalScope scop_out = new EditorGUILayout.VerticalScope())
        {
            using (EditorGUILayout.HorizontalScope h_scope = new EditorGUILayout.HorizontalScope())
            {
                EditorGUI.BeginChangeCheck();
                config.objectReferenceValue = EditorGUILayout.ObjectField("NVRConfiguration", config.objectReferenceValue, typeof(NVRConfiguration), false);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                    LoadNVRConfiguration();
                }
                if (!config.objectReferenceValue)
                {
                    GUI.skin.button.wordWrap = true;
                    if (GUILayout.Button(new GUIContent(" load ", "加载配置，如无则自动创建"), GUILayout.Width(0)))
                    {
                        config.objectReferenceValue = NVRConfiguration.Create();
                        LoadNVRConfiguration();
                    }
                }
            }
            // Draw nested inspector
            if (editor)
            {
                using (EditorGUILayout.VerticalScope scop = new EditorGUILayout.VerticalScope("box"))
                {
                    EditorGUI.indentLevel++;
                    editor.DrawConfigurationHandler();
                    editor.DrawList();
                    EditorGUI.indentLevel--;
                }
            }
        }
    }
    private void LoadNVRConfiguration()
    {
        editor = config.objectReferenceValue ? CreateEditor(config.objectReferenceValue) as NVRConfigurationEditor : null;
    }
}
