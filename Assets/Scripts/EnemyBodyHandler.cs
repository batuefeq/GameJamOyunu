using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyHandler : MonoBehaviour
{

    private void Update()
    {
        Handler();
    }

    private void Handler()
    {
        if (GetComponentInParent<Enemy>().isGrounded)
        {
            GetComponent<Animator>().SetBool("isGrounded", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isGrounded", false);
        }
    }
}
