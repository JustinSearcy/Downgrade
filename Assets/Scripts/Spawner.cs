using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float startTimeBetweenSpawns = 3f;

    float timeBetweenSpawns;

    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Update()
    {
        if(timeBetweenSpawns <= 0)
        {
            int randPoint = Random.Range(0, spawnPoints.Length);
            int randEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randEnemy], spawnPoints[randPoint].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
