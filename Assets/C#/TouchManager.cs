using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    Texture2D drawTexture; //テクスチャ―が入る変数
    Color[] buffer; //rgbの値が入る配列
    int size = 512;
    static public float dis = 100.0f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    //一番最初に実行される
    void Start()
    {
        Texture2D mainTexture = (Texture2D)GetComponent<Renderer>().material.mainTexture; //mainTextureに画像を入れる
        Color[] pixels = mainTexture.GetPixels(); //pixels配列の要素数は画像のピクセル分作成

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
    }

    //pには画面に当たった時のuv座標*ピクセル数が表示される
    public void Draw(Vector2 p)
    {
        Color color = new Color(1f, 1f, 1f, 0f);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if ((p - new Vector2(x, y)).magnitude < 12)
                {
                    buffer.SetValue(color, x + size * y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, dis))
            {
                Draw(hit.textureCoord * size);

            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        }
    }
}
