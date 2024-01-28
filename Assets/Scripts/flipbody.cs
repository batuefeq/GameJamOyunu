using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipbody : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FlipBody()
    {
        if (GetComponentInParent<ParryObjectCollider>().left)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FlipBody();


    }
}
