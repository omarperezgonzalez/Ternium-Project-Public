using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gameArchives : MonoBehaviour
{
    private string rutaArchivo;
    private string rutaArchivoTiempo;
    public static string URL;
    public GetDecisionResult result;

    void Awake(){
        //load();
        //loadTime();
        Debug.Log(URL);
        StartCoroutine(RequestData());
    }

    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                gameManagement.unlockLevels=0;
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                //Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetDecisionResult>(webRequest.downloadHandler.text);
                gameManagement.unlockLevels=result.decisions[0].Level;
                //playTime.time_=result.decisions[0].playedTime;
                //Debug.Log(gameManagement.unlockLevels);
            }
        }
    }

    public void save(){
        StartCoroutine(Upload());
    }

    IEnumerator Upload(){
        Decision newDecisions= new Decision();
        newDecisions.PlayedTime=result.decisions[0].PlayedTime;
        newDecisions.Level=gameManagement.unlockLevels;
        newDecisions.Decisions=result.decisions[0].Decisions;
        newDecisions.Score=result.decisions[0].Score;
        newDecisions.DECISIONESID=result.decisions[0].DECISIONESID;
        newDecisions.Name=result.decisions[0].Name;
        string jason13 = JsonUtility.ToJson(newDecisions);
        Debug.Log("JASON: "+ jason13);
        using (UnityWebRequest www= UnityWebRequest.Put(URL,jason13)){
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            if(www.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(www.isDone){
                Debug.Log("SIUUUUUUUU");
            }
        }
    }
}
