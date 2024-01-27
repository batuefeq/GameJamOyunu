using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAction : MonoBehaviour
{
    private float time = 2f;
    private float attackTime = 0.5f;
    private float speed = 5f;

    private void Swing()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Player.playerInstance.action == Player.PlayerAction.idle && time < 0)
            {
                time = 2f;
                ColliderOpener();

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().health -= collision.GetComponent<Enemy>().health;
        }
    }


    private void Position()
    {
        if (Player.playerInstance.side == Player.RotatedSide.left)
        {
            transform.GetChild(1).transform.position = Player.playerInstance.gameObject.transform.position + new Vector3(-1, 0, 0);
        }
        else
        {
            transform.GetChild(1).transform.position = Player.playerInstance.gameObject.transform.position + new Vector3(1, 0, 0);
        }
        
    }



    private void ColliderOpener()
    {
        transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
    }


    private void ColliderCloser()
    {
        if (attackTime < 0)
        {
            transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            Player.playerInstance.action = Player.PlayerAction.idle;
            attackTime = 0.5f;
            Player.speed = 10f;
        }
    }




    private void Timer()
    {
        if (time < 0)
        {
            Swing();
        }
        else
        {
            time -= Time.deltaTime;
        }
        if (transform.GetChild(1).GetComponent<BoxCollider2D>().enabled)
        {
            attackTime -= Time.deltaTime;
            Player.playerInstance.action = Player.PlayerAction.swing;
            Player.speed -= Time.deltaTime * speed;
        }
    }

    void Update()
    {
        ColliderCloser();
        Timer();
        Position();
    }
}
