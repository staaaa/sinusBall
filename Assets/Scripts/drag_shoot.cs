using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_shoot : MonoBehaviour
{
    //zmienne kulka
    float speed = 10f;
    float cX;
    float cY;
    Vector3 cVec;

    float sX;
    float sY;

    float a;
    float b;
    float c;

    static float right_left = 0;
    static float up_down = 0;

    bool kliknieto = false;
    bool puszczono = false;

    //zmienne strzalki
    float strX;
    float strY;
    Vector3 strVec;
    float strsX;
    float strsY;

    //gameobjects strzalki
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    private void FixedUpdate() 
    {
        strsX = this.transform.position.x;
        strsY = this.transform.position.y;
        strVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        strX = strVec.x - strsX;
        strY = strVec.y - strsY;

        //ruch kulki po puszczeniu
        if(puszczono == true)
        {
            Vector3 moveDirection = new Vector3(right_left, up_down);
            transform.position = transform.position + moveDirection * speed * Time.deltaTime;
            s1.GetComponent<SpriteRenderer>().sortingOrder = -5;
        }
        //strzalka
        strzalka();
    }

    private void OnMouseUp() {
        if(kliknieto == true)
        {
            sX = this.transform.position.x;
            sY = this.transform.position.y;
            cVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cX = cVec.x - sX;
            cY = cVec.y - sY;

            a = cY;
            b = cX;
            c = Mathf.Sqrt(Mathf.Pow(a,2) + Mathf.Pow(b,2));

            up_down = a/c;
            right_left = b/c;
            //oba c mniejsze od s
            if(cX < 0 && cY < 0)
            {
                if(up_down < 0)
                {
                    up_down *= -1;
                }
                if(right_left < 0)
                {
                    right_left *= -1;
                }
            }
            //cX wieksze niz sX i cY mniejsze niz sY
            else if(cX > 0 && cY < 0)
            {
                if(up_down < 0)
                {
                    up_down *= -1;
                }
                if(right_left > 0)
                {
                    right_left *= -1;
                }
            }
            //cX mniejsze od sX i cY wieksze od sY
            else if(cX < 0 && cY > 0)
            {
                if(up_down > 0)
                {
                    up_down *= -1;
                }
                if(right_left < 0)
                {
                    right_left *= -1;
                }
            }
            //Oba c wieksze od s
            else if(cX > 0 && cY > 0)
            {
                if(up_down > 0)
                {
                    up_down *= -1;
                }
                if(right_left > 0)
                {
                    right_left *= -1;
                }
            }
            kliknieto = false;
            puszczono = true;
        }
    }

    private void OnMouseDown() 
    {
        kliknieto = true;
        s1.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
    public static void zmianaPionowa()
    {
        up_down *= -1;
    }
    public static void zmianaPozioma()
    {
        right_left *= -1;
    }
    public void strzalka()
    {
        float ccX = strX;
        float ccY = strY;
        // if(ccX > 2f)
        // {
        //     ccX = 2f;
        // }
        // else if(ccX < -2f)
        // {
        //     ccX = -2f;
        // }
        // if(ccY > 2f)
        // {
        //     ccY = 2f;
        // }
        // else if(ccY < -2f)
        // {
        //     ccY = -2f;
        // }
        if(ccX > 0)
        {
            if(ccY > 0)
            {
                Vector3 vec = new Vector3(strsX-ccX,strsY-ccY);
                s1.transform.position = vec;
            }
            else if(ccY < 0)
            {
                Vector3 vec = new Vector3(strsX-ccX,strsY+ccY*-1);
                s1.transform.position = vec;
            }
        }
        else if(ccX < 0)
        {
            if(ccY > 0)
            {
                Vector3 vec = new Vector3(strsX+ccX*-1,strsY-ccY);
                s1.transform.position = vec;
            }
            else if(ccY < 0)
            {
                Vector3 vec = new Vector3(strsX+ccX*-1,strsY+ccY*-1);
                s1.transform.position = vec;
            }
        }
    }
}
