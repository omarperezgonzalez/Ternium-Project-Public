using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courier : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        DialogueController.courierDialogue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueController.courierDialogue = false;
    }
}
