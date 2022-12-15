using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursePort : MonoBehaviour
{
    public GameObject curse;
    private int koeff = 1;
    private int koeff2 = 0;
    [SerializeField] private float radius = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (koeff == 1)
            {
                koeff = -1;
            }
            else
            {
                koeff = 1;
            }
            if (collision.transform.position.x-curse.transform.position.x<0)
            {
                koeff2 = 1;
            }
            else
            {
                koeff2 = -1;
            }
            float randport = koeff2 * UnityEngine.Random.Range(radius-2f, radius);
            double circlepogr = Math.Sqrt(radius * radius - randport * randport);
            curse.transform.position = new Vector2(curse.transform.position.x + randport, curse.transform.position.y + koeff*(float)circlepogr);
        }
    }
}


