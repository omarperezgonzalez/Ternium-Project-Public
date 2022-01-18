using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tutorial_Dialogue : MonoBehaviour
{
    public Flowchart fc;
    public string bloque;
    private float velZAuxLim;
    // private int decision;


    public static bool tutorialDialogue;

    // Update is called once per frame
    void Update()
    {

        if (tutorialDialogue)
        {
            bloque = "Begin_Dialogue";
        }
        else
        {
            bloque = "emptyBlock";
        }


        if (Input.GetKeyDown(KeyCode.E) && tutorialDialogue)
        {
            fc.ExecuteBlock(bloque);
        }
        if (fc.GetBooleanVariable("InConversation"))
        {
            desactivarJugador();
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                DC_Tutorial.velz = 10;
            }
            else
            {
                reactivarjugador();
            }
        }

    }

    private void desactivarJugador()
    {
        DC_Tutorial.velz = 0;
        DC_Tutorial.velx = 0;
    }

    private void reactivarjugador()
    {
        DC_Tutorial.velz = 0.5f;
        DC_Tutorial.velx = 120;
    }

    private void OnTriggerEnter(Collider thing)
    {
        Debug.Log(gameObject.name + " was triggered by " + thing.gameObject.name);
    }
}
