using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 2f;
    private float time = 0f;
    public static EnemySpawner enemySpawner;

    public GameObject spawnLocationR, spawnLocationL;
    List<Vector3> locationLists = new();

    void Awake()
    {
        if (enemySpawner == null)
        {
            enemySpawner = this;
        }

        locationLists.Add(spawnLocationL.transform.position);
        locationLists.Add(spawnLocationR.transform.position);
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

    private void Spawn()
    {
        int rand = Random.Range(0, 2);

        Instantiate(GameManager.enemy, locationLists[rand], Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Spawn();
        }
        Spawner();
    }
}
