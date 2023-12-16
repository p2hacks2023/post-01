using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditWindow : MonoBehaviour
{
   public void NextEditWindow(){
        SceneManager.LoadScene("EditwinScene");
    }
}
