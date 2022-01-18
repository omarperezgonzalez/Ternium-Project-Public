using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class CustomQuestion
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    public bool isCorrect;

}
