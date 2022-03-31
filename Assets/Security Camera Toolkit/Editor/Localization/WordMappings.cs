using System.Collections.Generic;
using System.IO;
using System.Threading;
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
        List<MapCollection> mapCollections = new List<MapCollection>();

        static bool isChinese => (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN") && !Instance.reverse; //en-US 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix">配置文件前置索引 </param>
        /// <param name="label_key">多语言 key </param>
        /// <returns></returns>
        public static string GetSentence(string prefix, string key)
        {
            var sentence = $"#={key}"; //做好标记，方便查询失效的 key
            foreach (var item in Instance.mapCollections)
            {
                //2. 通过前置索引取回相应的配置文件
                if (item && item.name.StartsWith($"{prefix}-"))
                {
                    //3. 查询多语言 key value pair
                    int index_map = item.maps.FindIndex(v => v.key == key);
                    if (index_map != -1)
                    {
                        var map = item.maps[index_map];
                        // 4. 根据系统语言返回语句
                        sentence = isChinese ? map.chinese : map.english;
                    }
                    else
                    {
                        Debug.LogError($"{nameof(WordMappings)}:获取本地化数据失败， key {key} 不存在");
                    }
                }
            }
            return sentence;
        }

        [CustomEditor(typeof(WordMappings))]
        class WordMappingsEditor : Editor
        {
            private ReorderableList list;
            internal static readonly string undoAdd = "Add Element To Array";
            internal static readonly string undoRemove = "Remove Element From Array";
            private string message = @"
1. 为方便分开管理各个面板多语言数据设计此配置工具
2. 为快速定位 key 值，约定：生成配置表的名称需要定义一个前置索引，该表内的 key 需同步使用这个索引
3. 这种分表保存配置文件的形式在多人协作种值得推荐，但是将 asset 整合在一起的行为在多人协作中应该避免。
";
            private string tips;

            private void OnEnable()
            {
                list = new ReorderableList(serializedObject, serializedObject.FindProperty("mapCollections"), true, true, true, true);
                list.drawHeaderCallback = rect =>
                {
                    GUI.Label(rect, "Mapping Collections");
                };
                list.elementHeight = EditorGUIUtility.singleLineHeight;
                list.drawElementCallback += OnDrawListItem;
                list.onRemoveCallback += OnRemoveListItem;
                list.onAddCallback += OnAddListItem;
            }
            #region Reorderable List Callbacks
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
                    var itt = list.serializedProperty.GetArrayElementAtIndex(num);
                    itt.objectReferenceValue = null;
                    list.serializedProperty.DeleteArrayElementAtIndex(num);
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
                    ClearListCacheByRef();
                }
            }
            int index;

            private void OnAddListItem(ReorderableList list)
            {
                list.GrabKeyboardFocus();
                SerializedProperty serializedProperty = serializedObject.FindProperty("mapCollections").FindPropertyRelative("Array.size");
                serializedProperty.intValue++;
                serializedProperty.serializedObject.ApplyModifiedProperties();
                list.index = list.serializedProperty.arraySize - 1;
                var value = GenerateMapCollection($"01-ForNVRConfiguration");
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

            private void OnDrawListItem(Rect rect, int index, bool isActive, bool isFocused)
            {
                //根据index获取对应元素 
                SerializedProperty item = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.height -= 2;
                string name = "缺失";
                if (item.objectReferenceValue)
                {
                    var i_name = item.objectReferenceValue.name;
                    int s_index = i_name.IndexOf('-'); //约定使用 - 作为分隔符号
                    if (s_index != -1)
                    {
                        name = i_name.Substring(0, s_index);
                    }
                }
                EditorGUI.PropertyField(rect, item, new GUIContent("配置表前置索引： " + name));
            }

            #endregion

            public override void OnInspectorGUI()
            {
                var so = serializedObject;
                EditorGUI.BeginChangeCheck();
                so.Update();
                var style = new GUIStyle("box");
                style.normal.textColor = Color.green;
                EditorGUILayout.LabelField($"当前系统语言：{Thread.CurrentThread.CurrentCulture.Name}", style);
                var itr = serializedObject.GetIterator();
                itr.NextVisible(true); //跳过脚本名称
                itr.NextVisible(true); //取 Reverse bool 字段
                EditorGUILayout.PropertyField(itr);
                //itr.NextVisible(true); //取 mapCollections 字段
                //EditorGUILayout.PropertyField(itr);
                list.DoLayoutList();

                EditorGUILayout.HelpBox(tips, MessageType.Info);
                if (list.index >= 0 && list.index < list.count)
                {
                    SerializedProperty map_prop = list.serializedProperty.GetArrayElementAtIndex(list.index);
                    if (map_prop.objectReferenceValue)
                    {
                        tips = $"当前选中 Mapping Collection 是 ：{map_prop.objectReferenceValue.name} ";
                        var map_editor = CreateEditor(map_prop.objectReferenceValue, typeof(MapCollectionEditor)) as MapCollectionEditor;
                        map_editor.DoListLayout();
                    }
                }
                else
                {
                    tips = "选中任意 Mapping Collections 编辑多语言键值对信息";
                }
                EditorGUILayout.HelpBox(message, MessageType.Info);




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
}
