using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.Networking;

public class level3Script : MonoBehaviour
{
    public static float level3Time;

    public Flowchart fc;
    public string bloque;
    public static int decision3;
    public static int decision;
    public FirstPersonController fps;

    public GameObject NPC;
    public GameObject phone;

    public Text siguienteNivel;

    public static bool phoneConversation;
    public static bool jeffConversation;

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
        level3Time += Time.deltaTime;

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

        if(fc.GetBooleanVariable("jeffEnd")){
            siguienteNivel.enabled=true;
        }

        if(fc.GetBooleanVariable("jeffEnd") && Input.GetKeyDown(KeyCode.Q)){
            saveTime();
            cameraDesactivator();
            gameManagement.level3Complete=true;
            controlJuego.levelUnlockAction();
        }
        Debug.Log("DEC: "+decision3);
        
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
        if(fc.GetBooleanVariable("preFinalConv") && jeffConversation && !phoneConversation){
            bloque="End";
        } else{
            if(fc.GetBooleanVariable("jeffBegin") && fc.GetBooleanVariable("telPicked") && jeffConversation && !phoneConversation){
                decision=fc.GetIntegerVariable("decisionMade");
                //bloque="Mid";
                switch(decision3){
                    case 1:
                        switch(decision){
                            case 1:
                                bloque="final1_1";
                                break;
                            case 2:
                                bloque="final1_2";
                                break;
                            case 3:
                                bloque="final1_3";
                                break;
                        }
                        break;
                    case 2:
                        switch(decision){
                            case 1:
                                bloque="final2_1";
                                break;
                            case 2:
                                bloque="final2_2";
                                break;
                        }
                        break;
                    case 3:
                        switch(decision){
                            case 1:
                                bloque="final3_1";
                                break;
                            case 2:
                                bloque="final3_2";
                                break;
                        }
                        break;
                }
            } else{
                switch(decision3)
                {
                    case 1:
                        if(fc.GetBooleanVariable("jeffBegin") && fc.GetBooleanVariable("telPicked") && !jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } else if(fc.GetBooleanVariable("jeffBegin") && !jeffConversation && phoneConversation){
                            bloque="TelConv1";
                        } else if(jeffConversation && !phoneConversation){
                            bloque="Begin1";
                        } else if(!jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } 
                        break;
                    case 2:
                        if(fc.GetBooleanVariable("jeffBegin") && fc.GetBooleanVariable("telPicked") && !jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } else if(fc.GetBooleanVariable("jeffBegin") && !jeffConversation && phoneConversation){
                            bloque="TelConv2";
                        } else if(jeffConversation && !phoneConversation){
                            bloque="Begin2";
                        } else if(!jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } 
                        break;
                    case 3:
                        if(fc.GetBooleanVariable("jeffBegin") && fc.GetBooleanVariable("telPicked") && !jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } else if(fc.GetBooleanVariable("jeffBegin") && !jeffConversation && phoneConversation){
                            bloque="TelConv3";
                        } else if(jeffConversation && !phoneConversation){
                            bloque="Begin3";
                        } else if(!jeffConversation && phoneConversation){
                            bloque="Auxiliar";
                        } 
                        break;
                }
            }
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
                //Debug.Log(result.decisions[0].id);
                level3Time=result.decisions[0].PlayedTime;
                decision3=result.decisions[0].Decisions;
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
        newDecisions.PlayedTime=level3Time;
        newDecisions.Decisions=result.decisions[0].Decisions;
        newDecisions.Score=(int) level3Time*100;
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