using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 2;
    public int health;
    private Rigidbody2D rb;
    private float moveSpeed = 1f;

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
    

    private void BasicEnemyAI()
    {
        if (Player.isGrounded)
        {
            EnemyMove(Player.playerInstance.gameObject.transform.position);
        }
    }


    private void EnemyMove(Vector3 pos)
    {
        Vector2 dir = pos - transform.position;
        rb.velocity = dir.normalized * moveSpeed;
    }


    void Update()
    {
        DeathChecker();
        BasicEnemyAI();
    }
}
