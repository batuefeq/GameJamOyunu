using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public int health;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;

    private bool reachedR, reachedL;
    private bool seek = true;


    public enum RotatedSide
    {
        right,
        left
    }
    public RotatedSide side; 

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

    private void Rotater()
    {
        if (rb.velocity.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seek = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seek = true;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void BasicEnemyAI() // yere inince kovalayan.
    {
        if (Player.isGrounded && seek)
        {
            EnemyMove(Player.playerInstance.gameObject.transform.position);
        }
    }


    private float timer = 1.2f;
    private float jumpSpeed = 10f;
    private float xSpeed = 3f;

    private void JumperEnemy()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;       
        }

        if (timer < 0)
        {
            timer = 1.2f;
            Jump();
        }
    }


    private void OnDestroy()
    {
        Instantiate(GameManager.blowParticle, transform.position, Quaternion.identity);
        var obj = Instantiate(GameManager.health, transform.position, Quaternion.identity);
        Destroy(obj, 2f);
    }

    private void Jump()
    {
        rb.velocity = new Vector2((Player.playerInstance.gameObject.transform.position - transform.position).normalized.x * xSpeed, jumpSpeed);
        Rotater();
    }

    private float flyTimer = 1f;
    public bool isGrounded;

    private void FlyingEnemyAI() // UÇAN DÜÞMANLARIN AI
    {
        if (flyTimer > 0)
        {
            flyTimer -= Time.deltaTime;
        }

        if (flyTimer < 0)
        {
            flyTimer = 1.5f;
            EnemyMoveWithY(Player.playerInstance.gameObject.transform.position);
        }
    
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
            JumperEnemy();
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



    void Update()
    {
        DeathChecker();
        if (!gameObject.CompareTag("JumperEnemy"))         
        {
            Rotater();
        }
     
        MoveWithTag();
    }
}
