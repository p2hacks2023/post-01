using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
   public void NextWritingWindow(){
        SceneManager.LoadScene("WritingScene");
    }
}
