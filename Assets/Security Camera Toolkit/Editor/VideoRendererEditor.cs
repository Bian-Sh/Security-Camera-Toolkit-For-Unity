// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;
using UnityEditor;
using zFramework.Media;

[CustomEditor(typeof(VideoRenderer)), CanEditMultipleObjects]
public class VideoRendererEditor : Editor
{
    SerializedProperty queuesize;
    SerializedProperty framerate;
    SerializedProperty isrendering;

    SerializedProperty width;
    SerializedProperty height;
    SerializedProperty frameload;
    SerializedProperty framerend;
    SerializedProperty framedrop;
    SerializedProperty event_s;

    private void OnEnable()
    {
        width = serializedObject.FindProperty("lumaWidth");
        height = serializedObject.FindProperty("lumaHeight");
        queuesize = serializedObject.FindProperty("maxFrameQueueSize");
        frameload = serializedObject.FindProperty("frameLoad");
        framerend = serializedObject.FindProperty("frameRender");
        framedrop = serializedObject.FindProperty("frameDrop");
        event_s = serializedObject.FindProperty("OnStatisticsReported");
        framerate = serializedObject.FindProperty("framerate");
        isrendering = serializedObject.FindProperty("isRendering");
    }


    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();
        EditorGUI.BeginChangeCheck();

        GUI.enabled = false;
        EditorGUILayout.PropertyField(isrendering);
        GUI.enabled = true;
        EditorGUILayout.PropertyField(framerate);
        GUI.enabled = !Application.isPlaying || !isrendering.boolValue;
        EditorGUILayout.PropertyField(queuesize);
        GUI.enabled = true;

        DrawVideoFrameInfo();
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void DrawStatisticsInfo()
    {
        var itr = serializedObject.FindProperty("enableStatistics");
        EditorGUILayout.PropertyField(itr);
        if (itr.boolValue)
        {
            using (EditorGUILayout.VerticalScope scop_v = new EditorGUILayout.VerticalScope("box"))
            {
                GUI.enabled = false;
                frameload.stringValue = EditorGUILayout.TextField(new GUIContent("??????????", aboutFrameload), frameload.stringValue);
                framerend.stringValue = EditorGUILayout.TextField(new GUIContent("??????????", aboutFrameRend), framerend.stringValue);
                framedrop.stringValue = EditorGUILayout.TextField(new GUIContent("??????????", aboutFrameDrop), framedrop.stringValue);
                GUI.enabled = true;
            }
            EditorGUILayout.Space(8);
            EditorGUILayout.PropertyField(event_s);
        }
    }

    private void DrawVideoFrameInfo()
    {
        width.isExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(width.isExpanded, new GUIContent("????????", aboutfoldheader));
        if (width.isExpanded)
        {
            using (EditorGUILayout.VerticalScope scop_v = new EditorGUILayout.VerticalScope("box"))
            {
                GUI.enabled = false;
                width.intValue = EditorGUILayout.IntField("????????:", width.intValue);
                height.intValue = EditorGUILayout.IntField("????????:", height.intValue);
                using (EditorGUILayout.HorizontalScope scope_h = new EditorGUILayout.HorizontalScope())
                {
                    long rsl = width.intValue * height.intValue;
                    long size = rsl + rsl / 2;
                    EditorGUILayout.LongField("????????:", size);
                    EditorGUILayout.LabelField(" ?? ", GUILayout.Width(20));
                    EditorGUILayout.TextField((size / 1024 / 1024).ToString("F2"), GUILayout.Width(48));
                    EditorGUILayout.LabelField(" MB", GUILayout.Width(30));
                }
                GUI.enabled = true;
            }
            EditorGUILayout.Space(8);
            DrawStatisticsInfo();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
    #region Tooltips
    const string aboutFrameload = "???????????????????????????? ????????????????????FPS??";
    const string aboutFrameRend = "???????????????????????? RawImage ????????????????FPS??";
    const string aboutFrameDrop = "????????????????????????????????????????????????????FPS??";
    const string aboutfoldheader = "?????????????????????????????? Game ????????????????????";
    #endregion
}
