using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phone : MonoBehaviour
{
    public Text interaction;

    void Start() {
        interaction.enabled=false;
    }

    private void OnTriggerEnter(Collider other) {
        tutorialSript.phoneConversation=true;
        level2Script.phoneConversation=true;
        level3Script.phoneConversation=true;
        level4Script.phoneConversation=true;
        interaction.enabled=true;
    }

    private void OnTriggerExit(Collider other) {
        tutorialSript.phoneConversation=false;
        level2Script.phoneConversation=false;
        level3Script.phoneConversation=false;
        level4Script.phoneConversation=false;
        interaction.enabled=false;
    }
}
