using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int health;
    public static int maxHealth = 10;
    public static int damage;
    public static float speed;
    public static float jumpSpeed;
    public static float bulletSpeed = 10f;

    private Rigidbody2D rb;
    public static bool isGrounded;

    private float ySpeedConstraint = 10f;


    public enum RotatedSide
    {
        right,
        left
    }
    public RotatedSide side; // hangi tarafa bakýyor karakter

    public enum PlayerAction
    {
        idle,
        swing,
        parry,
    }

    public PlayerAction action;

    public static Player playerInstance;
    private float pushForce = 100f;
    private int projectileDamage = 1;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        health = 10;
        damage = 1;
        speed = 10f;
        jumpSpeed = 10f;
    }


    private void Movement()
    {
        float x_input = Input.GetAxisRaw("Horizontal");
        PlayerRotater(x_input);
        rb.velocity = new Vector2(x_input * speed, rb.velocity.y);
    }

    private static float timebtwSpawn = 0.1f;
    private static float startTimebtwSpawns = 0.1f;

    public static void Echo()
    {
        if (timebtwSpawn <= 0)
        {
            var obj = Instantiate(GameManager.echo, playerInstance.transform.position, Quaternion.identity);
            timebtwSpawn = startTimebtwSpawns;
        }
        else
        {
            timebtwSpawn -= Time.deltaTime;
        }
    }


    private void Health()
    {
        if (health <= 0)
        {
            GameManager.Restart();
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("HeadCollider"))
        {
            col.gameObject.GetComponent<Enemy>().health -= damage;
        }
        else if (col.collider.gameObject.CompareTag("Enemy"))
        {
            health -= col.gameObject.GetComponent<Enemy>().damage;
            Vector2 pushDirection = (col.transform.position - transform.position).normalized;
            pushDirection.y = 0;
            print(pushDirection);
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
        else if (col.collider.gameObject.CompareTag("Projectile"))
        {
            Destroy(col.gameObject);
            health -= projectileDamage;
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            health++;
            Destroy(collision.gameObject);
        }
    }

    private void PlayerRotater(float input)
    {
        if (input > 0)
        {
            side = RotatedSide.right;
        }
        else if (input < 0)
        {
            side = RotatedSide.left;
        }
    } // karakterin yönünü bul


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
    }


    private void ConstraintLooker()
    {
        if (rb.velocity.y > ySpeedConstraint)
        {
            rb.velocity = new Vector2(rb.velocity.x, ySpeedConstraint);
        }
    }

    private void Firing()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            if (side == RotatedSide.left)
            {
                FireHandler.FireBullet(transform.position + new Vector3(-1f, 0, 0), -bulletSpeed);
            }
            else
            {
                FireHandler.FireBullet(transform.position + new Vector3(1f, 0, 0), bulletSpeed);
            }
        }   
    }

    void Update()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.state == GameManager.State.talking)
            {
                return;
            }
        }
        if (GameManager.instance == null)
        {
            Movement();
            Jump();
            return;
        }

        
        print("Player health: " + health.ToString());
        ConstraintLooker();
        Movement();
        Jump();
        Firing();
        if (DeerCall.isJetpackActive)
        {
            Echo();
        }
        Health();
    }
}
