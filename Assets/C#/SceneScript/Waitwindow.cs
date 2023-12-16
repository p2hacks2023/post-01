using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waitwindow : MonoBehaviour
{
   public void NextWaitWindow(){
        TouchManager.dis = 0.0f;
        SceneManager.LoadScene("WaitScene");
    }
}

