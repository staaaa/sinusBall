using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontal_change : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        drag_shoot.zmianaPozioma();
    }
}
