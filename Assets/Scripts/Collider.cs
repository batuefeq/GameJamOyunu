using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public static int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
            collision.gameObject.GetComponentInChildren<BodyRedder>().time = collision.gameObject.GetComponentInChildren<BodyRedder>().timeRate;
            Destroy(gameObject);
        }  
    }
}
