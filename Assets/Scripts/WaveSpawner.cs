using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Manages the spawn and waves of enemies
public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    // Point where the enemy first spawns
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private float timeToSpawn = 0.5f;

    public TextMeshProUGUI waveCountText;

    private int waveIndex = 0;

    // Ticks down timer used for spawn logic and updates the text
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountText.text = Mathf.Round(countdown).ToString();
    }

    // Spawns enemies in function of the waveIndex, then increments it
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeToSpawn);
        }
        
    }

    // Spawns a new enemy on the spawnPoint
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
