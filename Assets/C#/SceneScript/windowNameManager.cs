using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class windowNameManager : MonoBehaviour
{
    public static string windowName = "はじまりのまど";

    // Start is called before the first frame update
    void Start()
    {
        var windowNameComponent = GetComponent<TextMeshProUGUI>();
        windowNameComponent.text = windowName;
    }
}
