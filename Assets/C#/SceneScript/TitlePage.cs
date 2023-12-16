using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePage : MonoBehaviour
{
    public GameObject window;
    public GameObject snow;
    
   public void NextWritingWindow(){
        DontDestroyOnLoad(window);
        DontDestroyOnLoad(snow);
        window.AddComponent<TouchManager>();
        SceneManager.LoadScene("WritingScene");
    }
}
