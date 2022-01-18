using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDContainer : MonoBehaviour
{
    public void IDFolder(string IDLogin){
        gameArchives.URL="http://localhost:3000/decision/"+IDLogin;
        Debug.Log("URL: "+gameArchives.URL);
    }

    /*private void Awake() {
        IDFolder("2");
    }*/
}
