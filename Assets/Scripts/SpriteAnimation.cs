using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private static Animator anim;
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

        if (Player.playerInstance.action == Player.PlayerAction.swing)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }


    public static void FireTrigger()
    {
        anim.SetTrigger("fireTrigger");
        print("inside");
    }

    void Update()
    {
        AnimHandler();
    }
}