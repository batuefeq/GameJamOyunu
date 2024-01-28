using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject bullet1, bullet2, bullet3, walker, chaser, flier, jumper, parryObject, projectile, blowParticle,echo, health;

    public static List<GameObject> enemyList = new();

    public static List<GameObject> bullets = new();


    public enum State
    {
        talking,
        playing
    }

    public State state;

    [SerializeField]
    private GameObject _bullet1, _bullet2, _bullet3, _walker, _chaser, _flier, _jumper, _parryObject, _projectile, _blowParticle, _echo, _health;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        health = _health;
        echo = _echo;
        blowParticle = _blowParticle;
        projectile = _projectile;
        parryObject = _parryObject;
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


    public static void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Player.health = Player.maxHealth;
            Player.playerInstance.gameObject.transform.position = new Vector3(0, 0, 0);
        }
        
    }

}
