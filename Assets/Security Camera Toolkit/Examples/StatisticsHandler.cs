using UnityEngine;
using UnityEngine.UI;

public class StatisticsHandler : MonoBehaviour
{
    public Text load;
    public Text render;
    public Text drop;
    public void OnStatisticsReported(string arg0, string arg1, string arg2) 
    {
        load.text = $"Load {arg0}";
        render.text = $"Rend {arg1}";
        drop.text = $"Drop {arg2}";
    }
}
