using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace zFramework.Localization
{
    public class MapCollection : ScriptableObject
    {
        public List<Map> maps = new List<Map>();
    }

    [CustomEditor(typeof(MapCollection))]
    public class MapCollectionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
        public void DoListLayout() 
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            var list = serializedObject.FindProperty("maps");
            EditorGUILayout.PropertyField(list);
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
