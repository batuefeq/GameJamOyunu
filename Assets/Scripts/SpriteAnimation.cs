using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void AnimHandler()
    {
        if (Player.playerInstance.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }



    void Update()
    {
        AnimHandler();
    }
}
