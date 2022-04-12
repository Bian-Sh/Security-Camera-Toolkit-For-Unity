// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using UnityEngine;
namespace zFramework.Media
{
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
}