using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    float ir = 1;
    private float fast = 2f;

    void Start()
    {
        
    }


    private void Fade()
    {
        ir -= Time.deltaTime * fast;
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, ir);
        if (GetComponent<SpriteRenderer>().color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Fade();
    }
}
