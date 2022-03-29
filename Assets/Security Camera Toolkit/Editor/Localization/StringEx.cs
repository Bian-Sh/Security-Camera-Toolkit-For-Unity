using System;
namespace zFramework.Localization
{
    public static class StringEx
    {
        public static string Allocate(this String key)
        {
            return WordMappings.GetSentence(key);
        }
    }
}