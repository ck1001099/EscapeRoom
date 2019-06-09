using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class ServerController
{
    public static IEnumerator ObjectOverlapping_DisplayTime(string url, System.Action callback){
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)){
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError){
                Debug.LogError("[ObjectOverlapping_DisplayTime] Network Error!");
            } else {
                Debug.Log("[ObjectOverlapping_DisplayTime] Success!");
            }
            callback();
        }
    }
}
