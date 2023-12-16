using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserAdd : MonoBehaviour
{
    
    public Text UserId;
    //出力用のテキスト

    //inputFieldのOnEndEditに設定する用の関数
    public void UserIdLine()
    {
        //InputFieldコンポーネントのtextを変数に代入
        string inputFieldText = GetComponent<InputField>().text;
        //出力用のテキストに代入
        UserId.text = inputFieldText;
    }
    
}
