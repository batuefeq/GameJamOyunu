using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParryObjectCollider : MonoBehaviour
{


    public bool left;
    private float speedAcc = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<ProjectileHandler>().hasParried = true;
            if (left)
            {
                if (collision.GetComponent<Rigidbody2D>().velocity.x > 0)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x * -speedAcc, 0);
                    print(collision.GetComponent<Rigidbody2D>().velocity.magnitude);
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x * speedAcc, 0);
                    print(collision.GetComponent<Rigidbody2D>().velocity.magnitude);
                }

                
            }
            else
            {
                if (collision.GetComponent<Rigidbody2D>().velocity.x > 0)
                {
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x * speedAcc, 0);
                    print(collision.GetComponent<Rigidbody2D>().velocity.magnitude);
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x * -speedAcc, 0);
                    print(collision.GetComponent<Rigidbody2D>().velocity.magnitude);
                }
            }

            Destroy(gameObject);
        }
        
    }

  
}
