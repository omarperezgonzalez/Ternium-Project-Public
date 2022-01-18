using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class decision2 : MonoBehaviour
{
    public Text interaction;
    public Flowchart fc;

    void Start() {
        interaction.enabled=false;
    }

    private void OnTriggerEnter(Collider other) {
        if(fc.GetBooleanVariable("jeffBegin")){
            interaction.enabled=true;
        } else {
            interaction.enabled=false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(!fc.GetBooleanVariable("phonePicked")){
            if(Input.GetKeyDown(KeyCode.E)){
                level4Script.decisionCuaderno=2;
            }
        } else{
            interaction.enabled=false;
        }
    }

    private void OnTriggerExit(Collider other) {
        interaction.enabled=false;
    }
}
