using UnityEngine;
using UnityEditor;
using zFramework.Media;

[CustomEditor(typeof(VideoRenderer)),CanEditMultipleObjects]
public class VideoRendererEditor : Editor
{
    SerializedProperty queuesize;
    SerializedProperty framerate;
    SerializedProperty isrendering;

    SerializedProperty width;
    SerializedProperty height;
    SerializedProperty datasize;
    SerializedProperty frameload;
    SerializedProperty framerend;
    SerializedProperty framedrop;
    SerializedProperty event_s;

    private void OnEnable()
    {
        width = serializedObject.FindProperty("lumaWidth");
        height = serializedObject.FindProperty("lumaHeight");
        datasize = serializedObject.FindProperty("frameDataSize");
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
                frameload.stringValue = EditorGUILayout.TextField(new GUIContent("推流帧率：", aboutFrameload), frameload.stringValue);
                framerend.stringValue = EditorGUILayout.TextField(new GUIContent("取流帧率：", aboutFrameRend), framerend.stringValue);
                framedrop.stringValue = EditorGUILayout.TextField(new GUIContent("丢弃帧率：", aboutFrameDrop), framedrop.stringValue);
                GUI.enabled = true;
            }
            EditorGUILayout.Space(8);
            EditorGUILayout.PropertyField(event_s);
        }
    }

    private void DrawVideoFrameInfo()
    {
        width.isExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(width.isExpanded, new GUIContent("视频信息",aboutfoldheader));
        if (width.isExpanded)
        {
            using (EditorGUILayout.VerticalScope scop_v = new EditorGUILayout.VerticalScope("box"))
            {
                GUI.enabled = false;
                width.intValue = EditorGUILayout.IntField("视频宽度:", width.intValue);
                height.intValue = EditorGUILayout.IntField("视频高度:", height.intValue);
                using (EditorGUILayout.HorizontalScope scope_h = new EditorGUILayout.HorizontalScope())
                {
                    datasize.longValue = EditorGUILayout.LongField("数据大小:", datasize.longValue);
                    EditorGUILayout.LabelField(" ≈ ", GUILayout.Width(20));
                    EditorGUILayout.TextField((datasize.longValue / 1024 / 1024).ToString("F2"), GUILayout.Width(48));
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
    const string aboutFrameload = "该数值表示在一秒内监控播放库 推送的数据量（单位：FPS）";
    const string aboutFrameRend = "该数值表示在一秒内绘制在 RawImage 上的帧数（单位：FPS）";
    const string aboutFrameDrop= "该数值表示在一秒内因为缓存队列满而丢弃的帧数（单位：FPS）";
    const string aboutfoldheader = "友情提示：展示里面的内容会导致 Game 窗口掉帧，请保持折叠";
    #endregion
}
