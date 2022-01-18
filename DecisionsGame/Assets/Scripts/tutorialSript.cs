using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.Networking;

public class tutorialSript : MonoBehaviour
{
    public static float tutoTime;

    public Flowchart fc;
    public string bloque;
    private int decision;
    public FirstPersonController fps;

    public Text siguienteNivel;

    public gameManagement controlJuego;

    public GameObject NPC;
    public GameObject phone;

    public static bool phoneConversation;
    public static bool jeffConversation;

    public GetDecisionResult result;

    void Awake() {
        //rutaArchivoTiempo=Application.persistentDataPath+"/timelapse.dat";
        StartCoroutine(RequestData());
    }

    void Start() {
        siguienteNivel.enabled=false;
        Time.timeScale=1f;
        phoneConversation=false;
        jeffConversation=false;
    }
    
    // Update is called once per frame
    void Update()
    {
        tutoTime += Time.deltaTime;
        dialogueManager();
    
        if(!phoneConversation && !jeffConversation){
            bloque="a";
        }
        if(Input.GetKeyDown(KeyCode.E)){
            fc.ExecuteBlock(bloque);
        }
        if(fc.GetBooleanVariable("inConversation")){
            desactivarJugador();
        } else {
            reactivarjugador();
        }
        if(fc.GetBooleanVariable("completeTuto1") && fc.GetBooleanVariable("completeTuto2")){
            siguienteNivel.enabled=true;
        }
        if(fc.GetBooleanVariable("completeTuto1") && fc.GetBooleanVariable("completeTuto2") && Input.GetKeyDown(KeyCode.Q)){
            cameraDesactivator();
            saveTime();
            gameManagement.tutoComplete=true;
            controlJuego.levelUnlockAction();
        }
    }

    private void desactivarJugador(){
        fps.m_WalkSpeed=0;
    }

    private void reactivarjugador(){
        fps.m_WalkSpeed=5;
    }

    private void OnTriggerEnter(Collider thing) {
        Debug.Log(gameObject.name + " was triggered by " + thing.gameObject.name);
    }

    private void dialogueManager(){
        if(jeffConversation && !phoneConversation){
            bloque="beginTuto1";
        }
        if(!jeffConversation && phoneConversation){
            bloque="beginTuto2";
        }
    }

    public void cameraDesactivator(){
        fps.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=false;
        Cursor.lockState=CursorLockMode.None;
        Cursor.lockState=CursorLockMode.Confined;
        Cursor.visible=true;
    }

    public void saveTime(){
        StartCoroutine(Upload());
    }

    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(gameArchives.URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetDecisionResult>(webRequest.downloadHandler.text);
                tutoTime=result.decisions[0].PlayedTime;
                //Debug.Log(result.decisions[0].id);
            }
        }
    }

    IEnumerator Upload(){
        Decision newDecisions= new Decision();
        if(Pause.PauseActive){
            newDecisions.Level=result.decisions[0].Level;
        } else{
            if(result.decisions[0].Level>gameManagement.maxLevel){
                newDecisions.Level=result.decisions[0].Level;
            } else{
                if(gameManagement.maxLevel>controlJuego.actualLevel){
                    newDecisions.Level=gameManagement.maxLevel;
                } else{
                    newDecisions.Level=controlJuego.actualLevel;
                }
            }
        }
        newDecisions.PlayedTime=tutoTime;
        newDecisions.Decisions=result.decisions[0].Decisions;
        newDecisions.Score=(int) tutoTime*100;
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
