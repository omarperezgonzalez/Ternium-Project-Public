using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        DialogueController.footmanDialogue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueController.footmanDialogue = false;
    }
}
