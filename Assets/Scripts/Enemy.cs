using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 2;
    public int health;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;

    private bool reachedR, reachedL;
    private bool seek = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private int Damage()
    {
        return damage;
    }

    private void DeathChecker()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seek = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seek = true;
        }
    }


    private void BasicEnemyAI() // yere inince kovalayan.
    {
        if (Player.isGrounded && seek)
        {
            EnemyMove(Player.playerInstance.gameObject.transform.position);
        }
    }

    private void WalkingEnemy()
    {
        
    }

    private void FlyingEnemyAI() // UÇAN DÜÞMANLARIN AI
    {
        EnemyMoveWithY(Player.playerInstance.gameObject.transform.position);
    }


    private void MoveWithTag()
    {
        if (transform.GetChild(0).gameObject.CompareTag("FlyingEnemy"))
        {
            FlyingEnemyAI();
        }
        else if (transform.GetChild(0).gameObject.CompareTag("WalkingEnemy"))
        {
            EnemyMoveWithoutPos();
        }
        else if (transform.GetChild(0).gameObject.CompareTag("ChaserEnemy"))
        {
            BasicEnemyAI();
        }
        else if (transform.GetChild(0).gameObject.CompareTag("JumperEnemy"))
        {

        }
    }

    private void EnemyMove(Vector3 pos)
    {
        Vector2 dir = pos - transform.position;
        rb.velocity = new Vector2(dir.normalized.x * moveSpeed, rb.velocity.y);
    }


    private void EnemyMoveWithY(Vector3 pos)
    {
        Vector2 dir = pos - transform.position;
        rb.velocity = dir.normalized * moveSpeed;
    }

    private void EnemyMoveWithoutPos()
    {
        if (transform.position == EnemySpawner.enemySpawner.spawnLocationL.transform.position)
        {
            reachedR = true;
            reachedL = false;
        }
        else if(transform.position == EnemySpawner.enemySpawner.spawnLocationR.transform.position)
        {
            reachedL = true;
            reachedR = false;
        }

        if (reachedR)
        {
            rb.velocity = EnemySpawner.enemySpawner.spawnLocationR.transform.position.normalized * moveSpeed;
        }
        else if(reachedL)
        {

            rb.velocity = EnemySpawner.enemySpawner.spawnLocationL.transform.position.normalized * moveSpeed;
        }        
    }

    private void JumperEnemy()
    {
        
    }


    void Update()
    {
        DeathChecker();
        MoveWithTag();
    }
}
