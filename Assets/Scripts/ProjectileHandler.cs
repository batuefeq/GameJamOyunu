using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 10f;

    private Vector2 dir;

    public bool hasParried;

    private void Handler()
    {
        if (!hasParried)
        {
            rb.velocity = new Vector2(dir.normalized.x * moveSpeed, dir.normalized.y * moveSpeed);
        }
    }


    void Start()
    {
        dir = Player.playerInstance.gameObject.transform.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        Handler();     
    }
}
