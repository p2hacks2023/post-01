using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public GameObject window;

    public void NextSendWindow(){
        DontDestroyOnLoad(window);
        var touchManager = window.GetComponent<TouchManager>();
        Destroy(touchManager);

        SceneManager.LoadScene("SendWindow");
    }
}
