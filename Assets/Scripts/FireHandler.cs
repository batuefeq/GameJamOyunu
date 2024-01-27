using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour
{
    public static float timer = 0;
    private static float timerMag = 0;
    public static float shootRate = 0.5f;
    public static int magSize = 7;
    public static int currentMag = 7;
    private float reloadRate = 2;

    private static bool reloading;

    public static void FireBullet(Vector3 pos, float speed)
    {
        if (!Timer() || reloading || Player.playerInstance.action != Player.PlayerAction.idle) return;
        int rand = Random.Range(0, GameManager.bullets.Count);
        SpriteAnimation.FireTrigger();
        GameObject bullet = Instantiate(GameManager.bullets[rand], pos, Quaternion.identity);
        currentMag--;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        Destroy(bullet, 2f);
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
            reloading = true;
            
        }
        if (timerMag >= reloadRate)
        {
            timerMag = 0;
            currentMag = magSize;
            reloading = false;
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
