using UnityEngine;
namespace zFramework.Localization
{
    public class GUIContentEx : GUIContent
    {
        public GUIContentEx(string label_key, string tooltip_key)
        {
            if (!string.IsNullOrEmpty(label_key))
            {
                this.text = WordMappings.GetSentence(label_key);
            }
            if (!string.IsNullOrEmpty(tooltip_key))
            {
                this.tooltip = WordMappings.GetSentence(tooltip_key);
            }
        }
    }
}