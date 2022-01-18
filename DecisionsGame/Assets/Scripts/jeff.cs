using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jeff : MonoBehaviour
{

    public Text interaction;

    void Start() {
        interaction.enabled=false;
    }

    private void OnTriggerEnter(Collider other) {
        level2Script.jeffConversation=true;
        tutorialSript.jeffConversation=true;
        level3Script.jeffConversation=true;
        level4Script.jeffConversation=true;
        interaction.enabled=true;
    }

    private void OnTriggerExit(Collider other) {
        level2Script.jeffConversation=false;
        tutorialSript.jeffConversation=false;
        level3Script.jeffConversation=false;
        level4Script.jeffConversation=false;
        interaction.enabled=false;
    }
}
