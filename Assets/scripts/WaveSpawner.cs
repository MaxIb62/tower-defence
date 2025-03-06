using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float Countdown = 2f;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown <= 0f)
        {
            SpawnWave();
            Countdown = timeBetweenWaves;
        }

        Countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        for (int i = 0; i< waveNumber; i++)
        {
            SpawnEnemy();
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
