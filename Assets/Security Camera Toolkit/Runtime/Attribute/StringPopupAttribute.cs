// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using System;
using System.Reflection;
using UnityEngine;
namespace zFramework.Media
{
    public class StringPopupAttribute : PropertyAttribute
    {
        public string[] Array
        {
            get;
            private set;
        }
        public string error;
        public StringPopupAttribute(Type type, string methodName,string error="")
        {
            this.error = error;
            var method = type.GetMethod(methodName);
            if (method != null)
            {
                Array = method.Invoke(null, null) as string[];
            }
            else
            {
                Debug.LogError("NO SUCH METHOD " + methodName + " FOR " + type);
            }
        }
    }
}