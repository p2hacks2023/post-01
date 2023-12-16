using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Button button;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += new Vector3(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (button != null) button.onClick.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "button")
        {
            button = collision.GetComponent<Button>();
            GetComponent<Image>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "button")
        {
            button = null;
            GetComponent<Image>().color = Color.white;
        }
    }
}
