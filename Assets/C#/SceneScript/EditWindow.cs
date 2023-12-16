using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditWindow : MonoBehaviour
{
   public void NextEditWindow(){
        TouchManager.dis = 0.0f;
        SceneManager.LoadScene("EditwinScene");
    }
}
