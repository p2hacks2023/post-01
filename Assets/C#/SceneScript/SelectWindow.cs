using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectWindow : MonoBehaviour
{
   public void NextSelectWindow(){
        SceneManager.LoadScene("SelectWindow");
    }
}
