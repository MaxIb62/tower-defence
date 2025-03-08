using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs; // Array con los 3 tipos de enemigos
    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float Countdown = 2f;
    private int waveIndex = 0;

    private int currentEnemies = 0;
    public int maxEnemies = 20;

    void Update()
    {
        if (Countdown <= 0f && currentEnemies < maxEnemies)
        {
            StartCoroutine(SpawnWave());
            Countdown = timeBetweenWaves;
        }

        Countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            if (currentEnemies >= maxEnemies)
                yield break;

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return; // Evita errores si no hay enemigos en la lista

        int randomIndex = Random.Range(0, enemyPrefabs.Length); // Elegir enemigo aleatorio
        Instantiate(enemyPrefabs[randomIndex], SpawnPoint.position, SpawnPoint.rotation);
        currentEnemies++;
    }

    public void EnemyDestroyed()
    {
        currentEnemies--;
    }
}
