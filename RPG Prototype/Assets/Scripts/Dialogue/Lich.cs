using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DialogueController.lichDialogue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueController.lichDialogue = false;
    }
}
