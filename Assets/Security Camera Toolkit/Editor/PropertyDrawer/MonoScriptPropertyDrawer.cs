// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace zFramework.Media
{
    [CustomPropertyDrawer(typeof(MonoScriptAttribute), false)]
    public class MonoScriptPropertyDrawer : PropertyDrawer
    {
        static Dictionary<string, MonoScript> m_ScriptCache;
        static MonoScriptPropertyDrawer()
        {
            m_ScriptCache = new Dictionary<string, MonoScript>();
            var scripts = Resources.FindObjectsOfTypeAll<MonoScript>();
            for (int i = 0; i < scripts.Length; i++)
            {
                var type = scripts[i].GetClass();
                if (type != null && !m_ScriptCache.ContainsKey(type.FullName))
                {
                    m_ScriptCache.Add(type.FullName, scripts[i]);
                }
            }
        }
        bool m_ViewString = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                Rect r = EditorGUI.PrefixLabel(position, label);
                Rect labelRect = position;
                labelRect.xMax = r.xMin;
                position = r;
                m_ViewString = GUI.Toggle(labelRect, m_ViewString, "", "label");
                if (m_ViewString)
                {
                    property.stringValue = EditorGUI.TextField(position, property.stringValue);
                    return;
                }
                MonoScript script = null;

                if (!string.IsNullOrEmpty(property.stringValue))
                {
                    string typeName = Type.GetType(property.stringValue).FullName;
                    if (!string.IsNullOrEmpty(typeName))
                    {
                        m_ScriptCache.TryGetValue(typeName, out script);
                        if (script == null)
                            GUI.color = Color.red;
                    }
                }
                script = (MonoScript)EditorGUI.ObjectField(position, script, typeof(MonoScript), false);
                if (GUI.changed)
                {
                    if (script != null)
                    {
                        var type = script.GetClass();
                        MonoScriptAttribute attr = (MonoScriptAttribute)attribute;
                        if (attr.type != null && !attr.type.IsAssignableFrom(type))
                            type = null;
                        if (type != null)
                        {
                            var targetClass = script.GetClass();
                            property.stringValue = targetClass.AssemblyQualifiedName;
                        }
                        else
                            Debug.LogWarning("The script file " + script.name + " doesn't contain an assignable class");
                    }
                    else
                        property.stringValue = "";
                }
            }
            else
            {
                GUI.Label(position, "The MonoScript attribute can only be used on string variables");
            }
        }
    }
}
