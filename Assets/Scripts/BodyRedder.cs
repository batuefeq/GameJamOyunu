using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRedder : MonoBehaviour
{
    public float time = 0;
    public float timeRate = 0.3f;


    private void Timer()
    {
        time -= Time.deltaTime;
        if (time >= 0)
        {
            MakeRed();
        }
        else
        {
            MakeNormal();
        }
    }

    private void MakeNormal()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }


    private void MakeRed()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
    }



    void Update()
    {
        Timer();
    }
}
