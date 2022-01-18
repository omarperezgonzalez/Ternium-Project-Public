using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Guy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Tutorial_Dialogue.tutorialDialogue = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Tutorial_Dialogue.tutorialDialogue = false;
    }
}
