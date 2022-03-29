using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace zFramework.Localization
{
    public partial class WordMappings : ScriptableObject
    {
        #region Single Instance / 单例
        const string soPath = "Security Camera Toolkit/Editor/Localization/Generated"; //存放 NVRConfiguration 实例
        static WordMappings _instance;
        public static WordMappings Instance
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
        private static WordMappings Load()
        {
            var file = Path.Combine("Assets", soPath, $"{nameof(WordMappings)}.asset");
            var so = AssetDatabase.LoadMainAssetAtPath(file);
            return so as WordMappings;
        }
        public static WordMappings Create()
        {
            if (!Instance)
            {
                var dir = Path.Combine(Application.dataPath, soPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                    AssetDatabase.Refresh();
                }
                var file = Path.Combine("Assets", soPath, $"{nameof(WordMappings)}.asset");
                var asset = CreateInstance<WordMappings>();
                AssetDatabase.CreateAsset(asset, file);
                AssetDatabase.Refresh();
            }
            EditorGUIUtility.PingObject(Instance);
            return Instance;
        }
        #endregion
        [SerializeField]
        bool reverse = true;
        [SerializeField]
        List<Map> maps = new List<Map>();
        [SerializeField]
        List<MapCollection> mapCollections = new List<MapCollection>();

        static bool isChinese => (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN") && !Instance.reverse; //en-US 
        public static string GetSentence(string key)
        {
            var sentence = key;
            int index = Instance.maps.FindIndex(v => v.key == key);
            if (index != -1)
            {
                var map = Instance.maps[index];
                sentence = isChinese ? map.chinese : map.english;
            }
            else
            {
                Debug.LogError($"{nameof(WordMappings)}:获取本地化数据失败， key {key} 不存在");
            }
            return sentence;
        }
    }

    [CustomEditor(typeof(WordMappings))]
    class WordMappingsEditor : Editor
    {
        private ReorderableList list;
        internal static readonly string undoAdd = "Add Element To Array";
        internal static readonly string undoRemove = "Remove Element From Array";

        private void OnEnable()
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("mapCollections"), true, true, true, true);
            list.drawHeaderCallback = rect =>
            {
                GUI.Label(rect, "Mapping Collections");
            };
            list.elementHeight = EditorGUIUtility.singleLineHeight;
            list.drawElementBackgroundCallback += OnDrawListItemBackground;
            list.drawElementCallback += OnDrawListItem;
            list.onRemoveCallback += OnRemoveListItem;
            list.onAddCallback += OnAddListItem;
        }

        private void OnAddListItem(ReorderableList list)
        {
            list.GrabKeyboardFocus();
            SerializedProperty serializedProperty = serializedObject.FindProperty("mapCollections").FindPropertyRelative("Array.size");
            serializedProperty.intValue++;
            serializedProperty.serializedObject.ApplyModifiedProperties();
            list.index = list.serializedProperty.arraySize - 1;
            var value = GenerateMapCollection("0-for nvr config");
            list.serializedProperty.GetArrayElementAtIndex(list.index).objectReferenceValue = value;
            list.serializedProperty.serializedObject.ApplyModifiedProperties();
            Undo.SetCurrentGroupName(undoAdd);
            ClearListCacheByRef();

        }

        private Object GenerateMapCollection(string file)
        {
            var mc = CreateInstance<MapCollection>();
            mc.name = file;
            AssetDatabase.AddObjectToAsset(mc, WordMappings.Instance);
            var path = AssetDatabase.GetAssetPath(WordMappings.Instance);
            var import = AssetImporter.GetAtPath(path);
            import.SaveAndReimport();
            return mc;
        }

        private void OnDrawListItemBackground(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (isFocused || isActive)
            {
                var color = isFocused ? new Color32(58, 114, 176, 255) : new Color32(174, 174, 174, 255);//174, 174, 174
                EditorGUI.DrawRect(rect, color);
            }
        }

        private void OnDrawListItem(Rect rect, int index, bool isActive, bool isFocused)
        {
            //根据index获取对应元素 
            SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex(index);

            rect.height -= 2;
            EditorGUI.PropertyField(rect, item, new GUIContent("Index " + index));
        }

        private void OnRemoveListItem(ReorderableList list)
        {
            int num = list.index;
            if (num < 0 || num >= list.count)
            {
                num = list.count - 1;
            }
            SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex(num);
            var obj = item.objectReferenceValue;

            if (EditorUtility.DisplayDialog("警告", $"此操作将丢弃 {obj?.name} 配置文件且不支持撤销，确认移除吗?", "移除", "取消"))
            {
                list.GrabKeyboardFocus();
                Debug.Log($"{nameof(WordMappingsEditor)}: before delete {list.count}");
                list.serializedProperty.DeleteArrayElementAtIndex(num);
                Debug.Log($"{nameof(WordMappingsEditor)}: after delete {list.count}");
                for (int i = num + 1; i < list.count; i++)
                {
                    Debug.Log($"{nameof(WordMappingsEditor)}: {num} - {i} - {list.index} - {list.count}");
                    SerializedProperty arrayElementAtIndex = list.serializedProperty.GetArrayElementAtIndex(i);
                    item.isExpanded = arrayElementAtIndex.isExpanded;
                    item = arrayElementAtIndex;
                }
                list.serializedProperty.arraySize -= 1;
                list.serializedProperty.serializedObject.ApplyModifiedProperties();
                if (list.index >= list.serializedProperty.arraySize - 1)
                {
                    list.index = list.serializedProperty.arraySize - 1;
                }

                if (obj)
                {
                    AssetDatabase.RemoveObjectFromAsset(obj);
                    var path = AssetDatabase.GetAssetPath(WordMappings.Instance);
                    var import = AssetImporter.GetAtPath(path);
                    import.SaveAndReimport();
                }
                Undo.SetCurrentGroupName(undoRemove);
                ClearListCacheByRef();
            }
        }

        public override void OnInspectorGUI()
        {
            var so = serializedObject;
            EditorGUI.BeginChangeCheck();
            so.Update();
            bool enterchildren = true;
            var itr = serializedObject.GetIterator();
            while (itr.NextVisible(enterchildren))
            {
                using (new EditorGUI.DisabledGroupScope("m_Script" == itr.propertyPath))
                {
                    EditorGUILayout.PropertyField(itr);
                }
                enterchildren = false;
            }
            list.DoLayoutList();

            if (EditorGUI.EndChangeCheck())
            {
                so.ApplyModifiedProperties();
            }
        }

        private void ClearListCacheByRef()
        {
            var method = list.GetType().GetMethod("ClearCache", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            method.Invoke(list, null);
        }
    }


}
