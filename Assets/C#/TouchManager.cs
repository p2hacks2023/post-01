using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class TouchScript : MonoBehaviour
{
    Texture2D drawTexture; //テクスチャ―が入る変数
    Color[] buffer; //rgbの値が入る配列

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

        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                if ((p - new Vector2(x, y)).magnitude < 5)
                {
                    buffer.SetValue(color, x + 256 * y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Draw(hit.textureCoord * 256);
            }

            drawTexture.SetPixels(buffer);
            drawTexture.Apply();
            GetComponent<Renderer>().material.mainTexture = drawTexture;
        }
    }
}
