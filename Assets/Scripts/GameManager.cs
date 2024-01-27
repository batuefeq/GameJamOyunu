using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject bullet1, bullet2, bullet3, walker, chaser, flier, jumper;

    public static List<GameObject> enemyList = new();

    public static List<GameObject> bullets = new();

    [SerializeField]
    private GameObject _bullet1, _bullet2, _bullet3, _walker, _chaser, _flier, _jumper;



    private void Awake()
    {
        bullet1 = _bullet1;
        bullet2= _bullet2;
        bullet3 = _bullet3;
        walker = _walker;
        chaser = _chaser;
        flier = _flier;
        jumper = _jumper;

        enemyList.Add(walker);
        enemyList.Add(chaser);
        enemyList.Add(flier);
        enemyList.Add(jumper);


        bullets.Add(bullet1);
        bullets.Add(bullet2);
        bullets.Add(bullet3);
    }

}
