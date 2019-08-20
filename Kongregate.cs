using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

public class Kongregate:MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void KongregateSubmitScore( string name, int value);
    [DllImport("__Internal")]
    private static extern void KongregateInitAPI(string ObjectName, string OnLoadedFunctionName);
    public static bool isKongregateReady;
    public static int userId;
    public static string username;
    public static string gameAuthToken;

    private void Start()
    {
#if !UNITY_EDITOR
        KongregateInitAPI(transform.name, "OnKongregateAPILoaded");
#endif
    }
    void OnKongregateAPILoaded(string userInfoString)
    {
        isKongregateReady = true;
        string[] parms = userInfoString.Split("|"[0]);
        userId = Convert.ToInt32(parms[0]); 
        username = parms[1];
        gameAuthToken = parms[2];
    }
    public static void SubmitScore (string name, int value)
    {
        if (isKongregateReady)
        KongregateSubmitScore(name, value);
    }
}
