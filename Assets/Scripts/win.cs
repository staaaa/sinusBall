using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    public Text text;

    public Button again;
    public Button menu;
    public Button next;

    public GameObject pilka;

    void Start()
    {
        again.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        text.enabled = true;
        again.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        pilka.transform.localScale = new Vector3(0f,0f,0f);
    }
}
