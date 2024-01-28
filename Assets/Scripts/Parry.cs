using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private float time = 3f;
    private float parryRate = 3f;
    private float parryTime = 0.7f;

    private void ParryHandler()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            time = 0f;
            if (Player.playerInstance.side == Player.RotatedSide.left)
            {
                var obj = Instantiate(GameManager.parryObject, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                obj.GetComponent<ParryObjectCollider>().left = true;
                Destroy(obj, parryTime);
            }
            else
            {
                var obj = Instantiate(GameManager.parryObject, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                Destroy(obj, parryTime);
            }       
        }
    }

    private void Parrier()
    {
        time += Time.deltaTime;
        if (time >= parryRate)
        {
            ParryHandler();     
        }
    }


    void Update()
    {
        Parrier();
    }
}
