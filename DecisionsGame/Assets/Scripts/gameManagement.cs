using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class gameManagement : MonoBehaviour
{
    gameArchives archives;
    static public int unlockLevels;
    static public int maxLevel;
    public int actualLevel;
    public Button[] menuButtons;

    private string rutaArchivo;
    private string rutaArchivoTiempo;
    public GetDecisionResult result;

    public Text timeLapseText;
    public static float time_;
    public Text scoreText;
    private int score;

    public static bool tutoComplete, level2Complete, level3Complete, level4Complete;

    void Awake(){
        StartCoroutine(RequestData());
    }

    void Update() {
        int seconds= (int)(time_ % 60);
        int minutes= (int)(time_ / 60) % 60;
        int hours= (int)(time_ / 3600) % 24;

        string timerString= string.Format("{0:0}:{1:00}:{2:00}",hours,minutes,seconds);
        score=(int) time_*100;

        if(SceneManager.GetActiveScene().name=="MenuPrincipal"){
            buttonsUpdate();
            timeLapseText.text="Tiempo jugado: "+ timerString;
            scoreText.text="Score: "+score;
        }
    }

    public void levelManagement(int level){
        if(level==0){
            SceneManager.LoadScene("MenuPrincipal");
        } else if(level==1){
            SceneManager.LoadScene("Tutorial");
        } else{
            SceneManager.LoadScene("Level_"+level);
        }
    }

    public void levelUnlockAction(){
        if(unlockLevels < actualLevel){
            unlockLevels=actualLevel;
            actualLevel++;
            back2Menu();
        }
        if(level4Complete){
            maxLevel=4;
            back2Menu();
        } else if(level3Complete){
            maxLevel=3;
            back2Menu();
        } else if(level2Complete){
            maxLevel=2;
            back2Menu();
        } else if(tutoComplete){
            maxLevel=1;
            back2Menu();
        } else{
            back2Menu();
        }
    }

    void back2Menu(){
        levelManagement(0);
    }

    public void buttonsUpdate(){
        for(int i=0;i<unlockLevels+1;i++){
            if(i<=3){
                menuButtons[i].interactable=true;
            }
        }
    }

    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(gameArchives.URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                gameManagement.unlockLevels=0;
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                //Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetDecisionResult>(webRequest.downloadHandler.text);
                //Debug.Log(gameManagement.unlockLevels);
                unlockLevels=result.decisions[0].Level;
                time_=result.decisions[0].PlayedTime;
            }
        }
    }


    public void load(){
        StartCoroutine(RequestData());
    }

    public void save(){
        StartCoroutine(Upload());
    }

    IEnumerator Upload(){
        Decision newDecisions= new Decision();
        newDecisions.PlayedTime=result.decisions[0].PlayedTime;
        newDecisions.Level=gameManagement.maxLevel;
        newDecisions.Decisions=result.decisions[0].Decisions;
        newDecisions.Score=result.decisions[0].Score;
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