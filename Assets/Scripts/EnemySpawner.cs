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


    public List<GameObject> list1 = new();
    public List<GameObject> list2 = new();
    public List<GameObject> list3 = new();
    public List<GameObject> list4 = new();
    public List<GameObject> list5 = new();
    public List<GameObject> list6 = new();
    public List<GameObject> list7 = new();


    public List<List<GameObject>> allLists = new();

    public GameObject spawnLocationR, spawnLocationL, proSpawnL, proSpawnR;
    List<Vector3> locationLists = new();
    List<Vector3> locationListProj = new();

    void Awake()
    {
        allLists.Add(list1);
        allLists.Add(list2);
        allLists.Add(list3);
        allLists.Add(list4);
        allLists.Add(list5);
        allLists.Add(list6);
        allLists.Add(list7);
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
        if (GameManager.instance.state == GameManager.State.playing)
        {
            int rand = Random.Range(0, 2);
            Instantiate(GameManager.projectile, locationListProj[rand], Quaternion.identity);
        }
    }




    private void Spawn()
    {
        int rand = Random.Range(0, 2);
        if (GameManager.instance.state == GameManager.State.playing)
        {
            if (allLists[WaveHandler.WaveNumber].Count > 0)
            {
                var obj = Instantiate(allLists[WaveHandler.WaveNumber][0], locationLists[rand], Quaternion.identity);
                allLists[WaveHandler.WaveNumber].RemoveAt(0);
                enemyList.Add(obj);
            }

        }
    }

    void Update()
    {
        ProjectileTimer();
        Spawner();
    }
}
