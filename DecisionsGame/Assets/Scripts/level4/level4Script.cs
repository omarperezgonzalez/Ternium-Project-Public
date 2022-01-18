using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.Networking;

public class level4Script : MonoBehaviour
{
    public static float level4Time;

    public Flowchart fc;
    public string bloque;
    public static int decision3;
    public static int decisionPhone;
    public FirstPersonController fps;

    public GameObject NPC;
    public GameObject phone;

    public Text siguienteNivel;

    public static bool phoneConversation;
    public static bool jeffConversation;
    public static int decisionCuaderno;

    public gameManagement controlJuego;

    public static GetDecisionResult result;

    void Awake() {
        StartCoroutine(RequestData());
    }

    void Start(){
        siguienteNivel.enabled=false;
        Time.timeScale=1f;
        phoneConversation=false;
        jeffConversation=false;
    }

    // Update is called once per frame
    void Update()
    {
        level4Time += Time.deltaTime;

        dialogueManager();

        /*if(Pause.PauseActive){
            saveTime();
        }*/
    
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

        if(fc.GetBooleanVariable("oficialEnd")){
            siguienteNivel.enabled=true;
        }

        if(fc.GetBooleanVariable("oficialEnd") && Input.GetKeyDown(KeyCode.Q)){
            saveTime();
            cameraDesactivator();
            gameManagement.level4Complete=true;
            controlJuego.levelUnlockAction();
        }
        //Debug.Log("DEC: "+decisionCuaderno);
        Debug.Log("B: "+bloque);
        
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
        if(fc.GetBooleanVariable("endG") && jeffConversation && !phoneConversation){
            bloque="globalEnd1";
        }
        else if(fc.GetBooleanVariable("phonePicked") && jeffConversation && !phoneConversation){
            decisionPhone=fc.GetIntegerVariable("decision1");
            switch (decisionCuaderno)
            {
                case 1:
                    switch (decisionPhone)
                    {
                        default:
                            bloque="a";
                            break;
                        case 1:
                            bloque="end1_1";
                            break;
                        case 2:
                            bloque="end1_2";
                            break;
                        case 3:
                            bloque="end1_3";
                            break;
                    }
                    break;
                case 2:
                    switch (decisionPhone)
                    {
                        default:
                            bloque="a";
                            break;
                        case 1:
                            bloque="end2_1";
                            break;
                        case 2:
                            bloque="end2_2";
                            break;
                        case 3:
                            bloque="end2_3";
                            break;
                    }
                    break;
                case 3:
                    switch (decisionPhone)
                    {
                        default:
                            bloque="a";
                            break;
                        case 1:
                            bloque="end3_1";
                            break;
                        case 2:
                            bloque="end3_2";
                            break;
                        case 3:
                            bloque="end3_3";
                            break;
                    }
                    break;
            }
        } 
        else if(fc.GetBooleanVariable("jeffBegin") && !jeffConversation && phoneConversation){
            if(fc.GetBooleanVariable("phonePicked")){
                bloque="Auxiliar";
            } else{
                switch (decisionCuaderno)
                {
                    case 1:
                        bloque="phoneConv1";
                        break;
                    case 2:
                        bloque="phoneConv2";
                        break;
                    case 3:
                        bloque="phoneConv3";
                        break;
                }
            }
        }
        else if(jeffConversation && !phoneConversation){
            switch (decision3)
            {
                case 1:
                    bloque="Begin1";
                    break;
                case 2:
                    bloque="Begin2";
                    break;
                case 3:
                    bloque="Begin3";
                    break;
            }
        } else{
            bloque="Auxiliar";
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
                level4Time=result.decisions[0].PlayedTime;
                decision3=result.decisions[0].Decisions;
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
        newDecisions.PlayedTime=level4Time;
        newDecisions.Decisions=result.decisions[0].Decisions;
        newDecisions.Score=(int) level4Time*100;
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