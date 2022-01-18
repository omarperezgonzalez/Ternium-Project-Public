using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QnA_Input : MonoBehaviour
{
    public InputField Question_Text;
    public InputField Option1, Option2, Option3, Option4;
    public CustomQuestion qstn;
    public CustomQuestion answrs;
    public GameObject correctButton;
    // public GameObject[] buttonCorrect = GameObject.FindGameObjectsWithTag("ToggleButton");
    bool isCorrect;

    public void questionSubmission()
        {
            qstn.Question = Question_Text.text;
        }
    
    public void answersSubmission()
        {
            answrs.Answers = new string[4];
            answrs.Answers[0] = Option1.text;
            answrs.Answers[1] = Option2.text;
            answrs.Answers[2] = Option3.text;
            answrs.Answers[3] = Option4.text;
        }
      

}
