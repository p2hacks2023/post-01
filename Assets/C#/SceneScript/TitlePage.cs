using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePage : MonoBehaviour
{
    public GameObject window;
    
   public void NextWritingWindow(){
        DontDestroyOnLoad(window);
        window.AddComponent<TouchManager>();
        SceneManager.LoadScene("WritingScene");
    }
}
