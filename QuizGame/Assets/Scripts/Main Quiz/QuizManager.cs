using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject ReturnPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    public static string URL;
    public GetPreguntasResult result;

    private void Awake() {
        StartCoroutine(RequestData());
    }

    private void Start()
        {
            totalQuestions = QnA.Count;
            GoPanel.SetActive(false);
            ReturnPanel.SetActive(false);
            generateQuestion();
        }

    public void retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    void GameOver()
        {
            StartCoroutine(Upload());
            Quizpanel.SetActive(false);
            GoPanel.SetActive(true);
            ReturnPanel.SetActive(true);
            ScoreTxt.text = score + "/" + totalQuestions;
        }

    public void correct()
        {
            score += 1;
            QnA.RemoveAt(currentQuestion);
            StartCoroutine(waitForNext());
        }

    public void wrong()
        {
            QnA.RemoveAt(currentQuestion);
            StartCoroutine(waitForNext());
        }

    IEnumerator waitForNext()
        {
            yield return new WaitForSeconds(1);
            generateQuestion();
        }

    void SetAnswers()
        {
            for (int i = 0; i < options.Length; i++)
                {
                    var color = options[i].GetComponent<AnswerScript>().startColor;
                    color.a = 1f;
                    options[i].GetComponent<Image>().color = color;
                    options[i].GetComponent<AnswerScript>().isCorrect = false;
                    options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
                    
                    if(QnA[currentQuestion].CorrectAnswer == i+1)
                        {
                            options[i].GetComponent<AnswerScript>().isCorrect = true;
                        }
                }
        }

    void generateQuestion()
        {
            if(QnA.Count > 0)
                {
                    currentQuestion = Random.Range(0, QnA.Count);

                    QuestionTxt.text = QnA[currentQuestion].Question;
                    SetAnswers();
                }
            else
                {
                    Debug.Log("Ya no hay preguntas.");
                    GameOver();
                }
        }

    IEnumerator RequestData(){
        using (UnityWebRequest webRequest= UnityWebRequest.Get(URL)){
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(webRequest.isDone){
                Debug.Log(webRequest.downloadHandler.text);
                result = JsonUtility.FromJson<GetPreguntasResult>(webRequest.downloadHandler.text);
                //Debug.Log(result.decisions[0].id);
            }
        }
    }

    IEnumerator Upload(){
        Preguntas newPreguntas= new Preguntas();
        newPreguntas.Score=result.preguntados[0].Score+(score*10);
        newPreguntas.QUIZZID=result.preguntados[0].QUIZZID;
        newPreguntas.Name=result.preguntados[0].Name;
        string jasonFile = JsonUtility.ToJson(newPreguntas);
        Debug.Log("JASON: "+ jasonFile);
        using (UnityWebRequest www= UnityWebRequest.Put(URL,jasonFile)){
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            if(www.isNetworkError){
                Debug.Log("ERROR ERROR ERROR");
            } else if(www.isDone){
                Debug.Log("SIUUUUUUUU");
            }
        }
    }
}


[System.Serializable]
public class Preguntas{
    public int QUIZZID;
    public string Name;
    public int Score;
}

[System.Serializable]
public class GetPreguntasResult{
    public Preguntas[] preguntados;
}