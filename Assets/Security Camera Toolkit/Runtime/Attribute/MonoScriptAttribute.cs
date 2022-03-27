// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;
using System;

namespace zFramework.Media
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class MonoScriptAttribute : PropertyAttribute
    {
        public System.Type type;
    }
}