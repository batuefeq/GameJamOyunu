using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerCall : MonoBehaviour
{
    public static bool isJetpackActive = false;
    private float jetpackForce = 7f;
    private float jetpackDuration = 2f;



    private void ActivateJumpPack()
    {
        if (Input.GetKey(KeyCode.E) && !isJetpackActive && jetpackDuration > 0.2f)
        {
            isJetpackActive = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isJetpackActive = false;
        }
    }



    private void DeerCaller()
    {
        if (isJetpackActive)
        {
            if (jetpackDuration > 0)
            {
                ApplyJetpackForce();
                jetpackDuration -= Time.deltaTime;
            }
        }
    }

    private void DeactiveJetpackHandler()
    {
        if (!isJetpackActive && jetpackDuration <= 2f)
        {
            jetpackDuration += Time.deltaTime;
        }
    }



    private void ApplyJetpackForce()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jetpackForce);
    }


    void Update()
    {
        ActivateJumpPack();
        DeerCaller();
        DeactiveJetpackHandler();
    }
}
