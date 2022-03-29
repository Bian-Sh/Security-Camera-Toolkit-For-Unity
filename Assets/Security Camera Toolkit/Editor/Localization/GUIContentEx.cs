using UnityEngine;
namespace zFramework.Localization
{
    public class GUIContentEx : GUIContent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix">用于查询的前置索引</param>
        /// <param name="label_key"></param>
        /// <param name="tooltip_key"></param>
        public GUIContentEx(string prefix,string label_key, string tooltip_key)
        {
            if (!string.IsNullOrEmpty(label_key))
            {
                this.text = WordMappings.GetSentence(prefix, label_key);
            }
            if (!string.IsNullOrEmpty(tooltip_key))
            {
                this.tooltip = WordMappings.GetSentence(prefix, tooltip_key);
            }
        }
    }
}