// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditorInternal;
using UnityEngine;
using zFramework.Localization;
using zFramework.Media;
using static UnityEditor.EditorGUI;

[CustomEditor(typeof(NVRConfiguration))]
public class NVRConfigurationEditor : Editor
{
    NVRConfiguration manager;
    SerializedProperty list;
    GUIStyle title_style;
    ReorderableList r_list;
    private void OnEnable()
    {
        manager = target as NVRConfiguration;

        list = serializedObject.FindProperty("nvrs");
        r_list = new ReorderableList(serializedObject, list, true, true, true, true);
        r_list.elementHeightCallback = OnRecacElementHeight;
        r_list.drawElementCallback = OnDoListElementDraw;
        r_list.drawHeaderCallback = OnDrawerListHearder;
        r_list.drawElementBackgroundCallback = OnDrawerElementBG;
    }

    private void OnDrawerElementBG(Rect rect, int index, bool isActive, bool isFocused)
    {
        bool shouldHighlight = false;
        if (index < 0 || index > list.arraySize - 1) return;
        if (index == 0)
        {
            var prop = list.GetArrayElementAtIndex(index);
            var desc = prop.FindPropertyRelative("description");
            bool isGenerated = desc.stringValue.StartsWith("此配置由机器生成") && desc.stringValue.EndsWith("   ");
            shouldHighlight = isGenerated && rect.x > 1;  //一个 item 推 2次绘制，首次 rect.x = 1
            if (shouldHighlight)
            {
                desc.stringValue = desc.stringValue.TrimEnd();
                desc.serializedObject.ApplyModifiedProperties();
                r_list.index = 0;
                r_list.GrabKeyboardFocus();
                ReorderableList.defaultBehaviours.DrawElementBackground(rect, index, isActive, isFocused, true);
            }
        }
        ReorderableList.defaultBehaviours.DrawElementBackground(rect, index, isActive, isFocused, true);
    }

    private void OnDrawerListHearder(Rect rect)
    {
        rect.x -= 10;
        LabelField(rect, new GUIContentEx("01", "nvr_arr_label", "nvr_arr_tootip"), new GUIStyle("label") { fontStyle = FontStyle.Bold });
    }

    private float OnRecacElementHeight(int index)
    {
        var prop = list.GetArrayElementAtIndex(index);
        return prop.isExpanded ? GetPropertyHeight(prop, true) : EditorGUIUtility.singleLineHeight;
    }

    private void OnDoListElementDraw(Rect rect, int index, bool isActive, bool isFocused)
    {
        if (index >= 0 && index < list.arraySize)
        {
            var prop = list.GetArrayElementAtIndex(index);
            rect.x += 10;
            rect.width -= 20;
            PropertyField(rect, prop);
        }
    }

    public override void OnInspectorGUI()
    {
        title_style = title_style ?? new GUIStyle("box")
        {
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
            fontSize = 28,
            stretchWidth = true,
        };
        title_style.normal.textColor = new Color32(54, 101, 155, 255);
        EditorGUILayout.LabelField("nvr_config_title".Allocate("01"), title_style);
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
        serializedObject.UpdateIfRequiredOrScript();
        BeginChangeCheck();
        //EditorGUILayout.PropertyField(list);
        r_list.DoLayoutList();
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
1. NVR 配置最好只做新增，不做删减
2. NVR 配置文件全局只有一份(单例)
";
}

