using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserAdd : MonoBehaviour
{
    
    public GameObject UserId;
    public GameObject inputField;
    //出力用のテキスト

    //inputFieldのOnEndEditに設定する用の関数
    public void UserIdLine()
    {
        //InputFieldコンポーネントのtextを変数に代入
        string inputFieldText = inputField.GetComponent<Text>().text;
        //出力用のテキストに代入
        UserId.GetComponent<Text>().text = inputFieldText;
    }
    
}
