using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.Networking;

public class level2Script : MonoBehaviour
{
    public static float level2Time;

    public Flowchart fc;
    public string bloque;
    private int decision;
    public FirstPersonController fps;

    public GameObject NPC;
    public GameObject phone;

    public Text siguienteNivel;

    public static bool phoneConversation;
    public static bool jeffConversation;

    public gameManagement controlJuego;

    public GetDecisionResult result;

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
        level2Time += Time.deltaTime;

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

        if(fc.GetBooleanVariable("end")){
            siguienteNivel.enabled=true;
        }

        if(fc.GetBooleanVariable("end") && Input.GetKeyDown(KeyCode.Q)){
            saveTime();
            cameraDesactivator();
            gameManagement.level2Complete=true;
            controlJuego.levelUnlockAction();
        }
        /*Debug.Log("Jeff: "+jeffConversation);
        Debug.Log("Phone: "+phoneConversation);*/
        
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
        if(fc.GetBooleanVariable("beginJeff") && fc.GetBooleanVariable("telPicked") && fc.GetBooleanVariable("objectiveEnd") && jeffConversation && !phoneConversation){
            bloque="generalFinal";
        } else{
                if(fc.GetBooleanVariable("beginJeff") && fc.GetBooleanVariable("telPicked") && jeffConversation && !phoneConversation){
                    decision=fc.GetIntegerVariable("decisionMade");
                    //saveDec();
                    switch (decision)
                    {
                        case 1:
                            bloque="final1";
                            //aux3.decision3=1;
                            break;
                        case 2:
                            bloque="final2";
                            //aux3.decision3=2;
                            break;
                        case 3:
                            bloque="final3";
                            //aux3.decision3=3;
                            break;
                    }
                } else {
                    if(fc.GetBooleanVariable("endCall")==false){
                        if(fc.GetBooleanVariable("beginJeff") && phoneConversation && !jeffConversation){
                            bloque="phonePick";
                        } else{
                            if(jeffConversation && !phoneConversation){
                                bloque="beginJeff";
                            } else{
                                bloque="Auxiliar";
                            }
                        }
                    } else{
                        bloque="Auxiliar";
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
                level2Time=result.decisions[0].PlayedTime;
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
        if(fc.GetIntegerVariable("decisionMade")!=0){
            newDecisions.Decisions=fc.GetIntegerVariable("decisionMade");
        } else{
            newDecisions.Decisions=result.decisions[0].Decisions;
        }
        newDecisions.PlayedTime=level2Time;
        newDecisions.Score=(int) level2Time*100;
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