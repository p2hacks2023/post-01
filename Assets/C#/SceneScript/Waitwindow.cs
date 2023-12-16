using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waitwindow : MonoBehaviour
{
    int cnt = 0;

    public void NextWaitWindow(){
        TouchManager.dis = 0.0f;
        cnt++;
        if (cnt == 2) {
            SceneManager.LoadScene("WaitScene");
        }
    }
}

