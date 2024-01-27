using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour
{
    private static float timer = 0;
    private static float timerMag = 0;
    public static float shootRate = 0.5f;
    public static int magSize = 7;
    public static int currentMag = 7;
    private float reloadRate = 2;

    private static bool reloading;

    public static void FireBullet(Vector3 pos, float speed)
    {
        if (!Timer() || reloading) return;
        GameObject bullet = Instantiate(GameManager.bullet, pos, Quaternion.identity);
        currentMag--;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        Destroy(bullet, 2f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }


    private void Update()
    {
        MagController();
        timer += Time.deltaTime;
    }


    private void MagController()
    {
        if (currentMag == 0)
        {
            timerMag += Time.deltaTime;
            print("reloading");
            reloading = true;
            
        }
        if (timerMag >= reloadRate)
        {
            timerMag = 0;
            currentMag = magSize;
            reloading = false;
            print("reloaded");
        }
    }


    private static bool Timer()
    {  
        if (timer >= shootRate)
        {
            timer = 0f;
            return true;
        }

        return false;
    }
}
