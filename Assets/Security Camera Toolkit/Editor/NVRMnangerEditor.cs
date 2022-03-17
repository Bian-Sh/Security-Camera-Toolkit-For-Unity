using UnityEditor;
using UnityEngine;
using zFramework.Media;
using static UnityEditor.EditorGUI;

[CustomEditor(typeof(NVRManager))]
public class NVRMnangerEditor : Editor
{
    NVRManager manager;
    private void OnEnable()
    {
        manager = target as NVRManager;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        HandleConfiguration();
    }

    private void HandleConfiguration()
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
        if (GUILayout.Button(new GUIContent("保存配置", "如存在则覆盖，操作不可逆")))
        {
            manager.SaveNvrConfiguration();
        }
        EditorGUILayout.EndHorizontal();
    }
}

