using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveWindowNameBtn : MonoBehaviour
{
    public GameObject windowNameInput;

    // Start is called before the first frame update
    public void SaveWindowName()
    {
        var windowNameInputComponent = windowNameInput.GetComponent<Text>();
        windowNameManager.windowName = windowNameInputComponent.text;
    }
}
