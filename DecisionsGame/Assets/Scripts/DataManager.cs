using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    public GetDecisionResult result;

    private void Awake() {
        //StartCoroutine(Upload());
        StartCoroutine(RequestData());
    }

    private void Update() {
        Finish();
    }

    public void Finish(){
        if(Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(Upload());
        }
    }
    
    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(gameArchives.URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetDecisionResult>(webRequest.downloadHandler.text);
                //Debug.Log(result.decisions[0].id);
            }
        }
    }

    IEnumerator Upload(){
        Decision newDecisions= new Decision();
        newDecisions.PlayedTime=0;
        newDecisions.Level=0;
        newDecisions.Decisions=0;
        newDecisions.Score=0;
        newDecisions.DECISIONESID=result.decisions[0].DECISIONESID;
        newDecisions.Name=result.decisions[0].Name;
        string jason13 = JsonUtility.ToJson(newDecisions);
        Debug.Log("JASON: "+ jason13);
        using (UnityWebRequest www= UnityWebRequest.Put(gameArchives.URL,jason13)){
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

[System.Serializable]
public class Decision{
    public int DECISIONESID;
    public string Name;
    public float PlayedTime;
    public int Level;
    public int Decisions;
    public int Score;
}

[System.Serializable]
public class GetDecisionResult{
    public Decision[] decisions;
}