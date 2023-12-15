using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;

public class FirestoreScript : MonoBehaviour
{
    public void Start()
    {
        var db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("cities").Document("LA");
        Dictionary<string, object> city = new Dictionary<string, object>
        {
                { "Name", "Los Angeles" },
                { "State", "CA" },
                { "Country", "USA" }
        };
        docRef.SetAsync(city).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the LA document in the cities collection.");
        });
    }
}