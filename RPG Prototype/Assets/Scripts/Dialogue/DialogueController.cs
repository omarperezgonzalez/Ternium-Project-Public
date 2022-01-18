using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueController : MonoBehaviour
{
    public Flowchart fc;
    public Flowchart fc2;
    public Flowchart fc3;
    public string bloque; 
    private float velZAuxLim;
    // private int decision;


    public static bool footmanDialogue; 
    public static bool courierDialogue;
    public static bool lichDialogue;

    // Update is called once per frame
    void Update()
    {
        
        if(footmanDialogue)
            {
                bloque = "Begin_Dialogue";
            }
        else if(courierDialogue)
            {
                bloque = "Courier_Dialogue";
            }
        else if(lichDialogue)
            {
                bloque = "Lich_Dialogue";
            }
        else
            {
                bloque = "emptyBlock";
            }
        
        
        if(Input.GetKeyDown(KeyCode.E) && footmanDialogue)
        {
            fc.ExecuteBlock(bloque);
        }
        else if(Input.GetKeyDown(KeyCode.E) && courierDialogue)
        {
            fc2.ExecuteBlock(bloque);
        }
        else if (Input.GetKeyDown(KeyCode.E) && lichDialogue)
        {
            fc3.ExecuteBlock(bloque);
        }
        
        if(fc.GetBooleanVariable("InConversation"))
            {
                desactivarJugador();
            } 
        else 
            {
                if(Input.GetKey(KeyCode.LeftShift))
                    {
                        DogController.velz=10;
                    }
                else
                    {
                        reactivarjugador();
                    }
            }
        
        if(fc2.GetBooleanVariable("InConversation"))
            {
                desactivarJugador();
            } 
        else 
            {
                if(Input.GetKey(KeyCode.LeftShift))
                    {
                        DogController.velz=10;
                    }
                else
                    {
                        reactivarjugador();
                    }
            }
        Debug.Log("VelZ: "+ DogController.velz);
    }

    private void desactivarJugador(){
        DogController.velz=0;
        DogController.velx=0;
    }

    private void reactivarjugador(){
        DogController.velz=0.5f;
        DogController.velx=120;
    }

    private void OnTriggerEnter(Collider thing) {
        Debug.Log(gameObject.name + " was triggered by " + thing.gameObject.name);
    }
}
