using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    public static GetPreguntasResult result;
    public static string URL;

    private void Awake() {
        StartCoroutine(RequestData());
    }

    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetPreguntasResult>(webRequest.downloadHandler.text);
                //Debug.Log(result.decisions[0].id);
            }
        }
    }
}
