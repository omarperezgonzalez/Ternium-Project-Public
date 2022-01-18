using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class loadSceneManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void IDAsk();

    void Awake(){
        IDAsk();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
