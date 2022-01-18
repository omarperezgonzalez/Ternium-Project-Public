using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestionAndAnswers[] quiz;
    public List<QuestionAndAnswers> userQuestions;
    void Awake()
    {
        userQuestions = new List<QuestionAndAnswers>();
        // LoadUserQuestions()
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void createNewQuestion () {
        QuestionAndAnswers newQuestion = new QuestionAndAnswers();
        newQuestion.CorrectAnswer = 1;
        newQuestion.Question = "Pregunta 1";

        userQuestions.Add(newQuestion);
        // SaveUserQuestions();
    }
}
