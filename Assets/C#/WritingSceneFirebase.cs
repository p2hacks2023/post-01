using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine.UI;
using TMPro;

public class WritingSceneFirebase : MonoBehaviour
{
    FirebaseFirestore db;
    public TextMeshProUGUI LastUpdateString;

    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("windowList").Document("myWindow");
        docRef.Listen(snapshot => {
            Dictionary<string, object> window = snapshot.ToDictionary();
            var timestamp = (Timestamp)window["Date"];
            var DateTime = timestamp.ToDateTime();
            
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime LastUpdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime, tzi);
            string FormattedLastUpdate = LastUpdate.ToString("最終更新日: MM月dd日 HH時mm分");

            Debug.Log(FormattedLastUpdate);
            LastUpdateString.text = FormattedLastUpdate;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
