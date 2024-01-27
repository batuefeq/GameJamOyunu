using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate;
    private float time;

    public GameObject spawnLocationR, spawnLocationL;
    List<Vector3> locationLists = new();

    void Start()
    {
        locationLists.Add(spawnLocationL.transform.position);
        locationLists.Add(spawnLocationR.transform.position);
    }


    private void Spawner()
    {
        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            Spawn();
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
            Spawner();
        }
    }
}
