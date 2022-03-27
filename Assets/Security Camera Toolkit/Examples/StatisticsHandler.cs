// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.
using UnityEngine;
using UnityEngine.UI;
namespace zFramework.Media.Demo
{
    public class StatisticsHandler : MonoBehaviour
    {
        public Text load;
        public Text render;
        public Text drop;
        [StringPopup(typeof(AA), "GetArray")]
        public string msg;
        public void OnStatisticsReported(string arg0, string arg1, string arg2)
        {
            load.text = $"Load {arg0}";
            render.text = $"Rend {arg1}";
            drop.text = $"Drop {arg2}";
        }


        static class AA
        {
            public static string[] GetArray()
            {
                return new string[4]
                {
                "string01",
                "string02",
                "string03",
                "string04"
                };
            }
        }
    }
}