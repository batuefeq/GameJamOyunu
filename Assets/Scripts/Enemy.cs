using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int damage = 2;
    public int health;

    private int Damage()
    {
        return damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.health -= Damage();
        }
    }

    private void DeathChecker()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        DeathChecker();
    }
}
