using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Firestore;
using Firebase.Storage;
using UnityEngine;

public class FirestoreScript : MonoBehaviour
{
    // キャプチャされた画像データ
    byte[] dataImage = new byte[]{};
    public GameObject canvas;

    string windwoUrl = "";

    public void sendWindow()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef = storage.GetReferenceFromUrl("gs://ice-window.appspot.com");

        StartCoroutine(DoScreenShot());

        StorageReference windowRef = storageRef.Child("myWindow.jpg");
        windowRef.PutBytesAsync(dataImage).ContinueWith((Task<StorageMetadata> task) => {
            if (task.IsFaulted || task.IsCanceled) {
                Debug.Log(task.Exception.ToString());
            }
            else {
                StorageMetadata metadata = task.Result;
                string md5Hash = metadata.Md5Hash;
                Debug.Log("Finished uploading...");
                Debug.Log("md5 hash = " + md5Hash);
            }
        });

        windowRef.GetDownloadUrlAsync().ContinueWithOnMainThread(task => {
            if (!task.IsFaulted && !task.IsCanceled) {
                windwoUrl = task.Result.ToString();
                Debug.Log("Download URL: " + task.Result);
            }
        });

        DateTime dt;
        dt = DateTime.Now;

        var db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("windowList").Document("myWindow");
        Dictionary<string, object> city = new Dictionary<string, object>
        {
                { "URL", windwoUrl },
                { "Date", dt},
        };
        docRef.SetAsync(city).ContinueWithOnMainThread(task => {
            Debug.Log("Added data.");
        });
    }

    IEnumerator DoScreenShot()
    {
        Debug.Log($"DoScreenShot");

        canvas.SetActive(false);
 
        // レンダリング後に処理を開始
        yield return new WaitForEndOfFrame();
 
        // Texture2D でスクリーンショットを取得
        Texture2D textureScreenCapture = ScreenCapture.CaptureScreenshotAsTexture();
 
        // EncodeToJPG で JPEG に変換する。EncodeToPNG なら PNG に変換できる
        dataImage = textureScreenCapture.EncodeToJPG();
 
        Debug.Log($"撮影完了");
 
        // textureScreenCapture を削除
        UnityEngine.Object.Destroy(textureScreenCapture);

        canvas.SetActive(true);
    }
}