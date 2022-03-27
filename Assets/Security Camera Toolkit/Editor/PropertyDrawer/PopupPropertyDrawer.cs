// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System;
using UnityEditor;
using UnityEngine;
namespace zFramework.Media
{
    [CustomPropertyDrawer(typeof(StringPopupAttribute))]
    public class PopupPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attribute = base.attribute as StringPopupAttribute;
            var list = attribute.Array;
            if (property.propertyType == SerializedPropertyType.String)
            {
                var nodata = null == list || list.Length == 0;
                if (nodata)
                {
                    var thirdpart = string.IsNullOrEmpty(attribute.error) ? "数据获取失败" : attribute.error;
                    var insertitem = string.IsNullOrEmpty(property.stringValue) ? thirdpart : property.stringValue;
                    list = new string[] { insertitem };
                    using (var scope = new BackgroundColorScope(Color.red))
                    {
                        var index = 0;
                        index = EditorGUI.Popup(position, property.displayName, index, list);
                    }
                }
                else
                {
                    //处理 string 数据丢失，这个情况下，先持有原来的数据，再在 控制台、inpsctor面板上进行通知
                    int index = Array.IndexOf(list, property.stringValue);
                    using (var scope = new BackgroundColorScope())
                    {
                        scope.Set(index == -1 ? Color.red : scope.orign);
                        if (index == -1)
                        {
                            index = list.Length;
                            Array.Resize(ref list, index + 1);
                            list[index] = property.stringValue;
                        }
                        index = EditorGUI.Popup(position, property.displayName, index, list);
                        property.stringValue = list[index];
                    }
                }
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, list);
            }
            else
            {
                base.OnGUI(position, property, label);
            }
            property.GetEndProperty();
        }
    }
}
public class BackgroundColorScope : GUI.Scope
{
    public readonly Color orign;
    public BackgroundColorScope()
    {
        this.orign = GUI.backgroundColor;
    }
    public BackgroundColorScope(Color color) : this()
    {
        GUI.backgroundColor = color;
    }
    public void Set(Color color)
    {
        GUI.backgroundColor = color;
    }
    protected override void CloseScope()
    {
        GUI.backgroundColor = this.orign;
    }
}