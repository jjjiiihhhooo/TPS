using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static Dictionary<float, WaitForSeconds> Seconds_Dic;

    public static WaitForSeconds GetWaitForSeconds(float time)
    {
        if (Seconds_Dic == null) Seconds_Dic = new Dictionary<float, WaitForSeconds>();

        if (!Seconds_Dic.ContainsKey(time)) Seconds_Dic.Add(time, new WaitForSeconds(time));

        return Seconds_Dic[time];
    }
}
