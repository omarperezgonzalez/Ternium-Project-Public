using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class QuestionAndAnswers: ScriptableObject
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    
}
