using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour
{
    public static void FireBullet(Vector3 pos, float speed)
    {
        GameObject bullet = Instantiate(GameManager.bullet, pos, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        Destroy(bullet, 2f);
    }
}
