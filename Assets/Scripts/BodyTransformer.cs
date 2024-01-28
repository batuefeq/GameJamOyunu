using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransformer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    
    private void FlipBody()
    {
        if (Player.playerInstance.side == Player.RotatedSide.left)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }



    void Update()
    {
        FlipBody();
    }
}
