using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour
{
    public static bool PauseActive;
    bool active;
    Canvas canvas;
    public FirstPersonController fps;

    // Start is called before the first frame update
    void Start()
    {
        PauseActive=false;
        canvas= GetComponent<Canvas>();
        canvas.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            PauseActive=!PauseActive;
            active=!active;
            canvas.enabled=active;
            Time.timeScale= (active) ? 0 : 1f;
            if(active){
                cameraDesactivator();
            } else{
                cameraActivator();
            }
        }
    }

    public void cameraDesactivator(){
        fps.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=false;
        Cursor.lockState=CursorLockMode.None;
        Cursor.lockState=CursorLockMode.Confined;
        Cursor.visible=true;
    }

    public void cameraActivator(){
        fps.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=true;
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.lockState=CursorLockMode.Confined;
        Cursor.visible=false;
    }
}
