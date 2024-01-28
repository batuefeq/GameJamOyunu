using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 2f;
    private float time = 0f;
    private float projectileSpawnRate = 2f;
    private float proTime = 0f;
    public static EnemySpawner enemySpawner;

    public static List<GameObject> enemyList = new();

    public GameObject spawnLocationR, spawnLocationL, proSpawnL, proSpawnR;
    List<Vector3> locationLists = new();
    List<Vector3> locationListProj = new();

    void Awake()
    {
        if (enemySpawner == null)
        {
            enemySpawner = this;
        }

        locationLists.Add(spawnLocationL.transform.position);
        locationLists.Add(spawnLocationR.transform.position);
        locationListProj.Add(proSpawnL.transform.position);
        locationListProj.Add(proSpawnR.transform.position);
    }


    private void Spawner()
    {
        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            Spawn();
            time = 0f;
        }
    }
    
    private void ProjectileTimer()
    {
        proTime += Time.deltaTime;
        if (proTime >= projectileSpawnRate)
        {
            ProjectileSpawner();
            proTime = 0f;
        }
    }

    private void ProjectileSpawner()
    {
        int rand = Random.Range(0, 2);
        Instantiate(GameManager.projectile, locationListProj[rand], Quaternion.identity);
    }

    private void Spawn()
    {
        int rand = Random.Range(0, 2);
        int randomEnemy = Random.Range(0, GameManager.enemyList.Count);

        var obj=  Instantiate(GameManager.enemyList[randomEnemy], locationLists[rand], Quaternion.identity);
        enemyList.Add(obj);
    }

    void Update()
    {
        ProjectileTimer();
        Spawner();
    }
}
