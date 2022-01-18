using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDContainer : MonoBehaviour
{
    public void IDFolder(string IDLogin){
        QuizManager.URL="http://localhost:3000/preguntados/"+IDLogin;
        DataManager.URL="http://localhost:3000/preguntados/"+IDLogin;
        Debug.Log("URL: "+QuizManager.URL);
    }
}
