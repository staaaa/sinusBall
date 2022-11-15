using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_menu : MonoBehaviour
{
    public void lvl1()
    {
        SceneManager.LoadScene("menu");
    }
    public void lvl2()
    {
        if(data.level >= 2)
        {
            SceneManager.LoadScene("#2");
        }
    }
}