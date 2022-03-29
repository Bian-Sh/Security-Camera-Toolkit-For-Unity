using System;
namespace zFramework.Localization
{
    public static class StringEx
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">多语言 key </param>
        /// <param name="prefix">配置文件前置索引</param>
        /// <returns></returns>
        public static string Allocate(this String key, string prefix)
        {
            return WordMappings.GetSentence(prefix, key);
        }
    }
}