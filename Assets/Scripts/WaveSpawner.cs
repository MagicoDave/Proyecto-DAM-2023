using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Manages the spawn and waves of enemies
public class WaveSpawner : MonoBehaviour
{
    // Used to determine the status of a wave, if it's compleated or not
    public static int EnemiesAlive = 0;
    // Wave array with the enemy data, ammount and rate and the index
    public Wave[] waves;
    private int waveIndex = 0;

    // Point where the enemy first spawns
    public Transform spawnPoint;
    // Time of wait between waves
    public float timeBetweenWaves = 5f;
    // Current countdown time
    private float countdown = 5f;

    // These two are used for the right canvas UI
    public TextMeshProUGUI nextWaveText;
    public TextMeshProUGUI waveNumberText;

    // Victory UI
    public GameObject youWonUI;

    // Initializes EnemiesAlive at zero
    void Start()
    {
        EnemiesAlive = 0;    
    }

    // Ticks down timer used for spawn logic and updates the text
    void Update()
    {
        // If enemies are still alive, just updates UI text
        if (EnemiesAlive > 0) 
        {
            nextWaveText.text = "Wave in progress...";
            return;
        }

        // When the last wave ends, stop spawning. Level won!
        if (waveIndex == waves.Length && !GameStateManager.gameOver)
        {
            Debug.Log("It entered the if clausule");
            youWonUI.SetActive(true);
            this.enabled = false;
        }

        // If there is no enemies left and the countdown reaches 0,
        // starts spawning enemies and resets the countdown
        if (countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        nextWaveText.text = "Next wave in " + string.Format("{0:00.00}", countdown);
    }

    // Spawns enemies from a Wave
    IEnumerator SpawnWave()
    {
        // Update the wave counter from PlayerStats and UI elements
        PlayerStats.wave++;
        waveNumberText.text = "Wave " + PlayerStats.wave.ToString();

        // Gets the current wave
        Wave wave = waves[waveIndex];

        // Spawns enemies from that wave at the rate of the wave
        for (int z = 0; z < wave.enemies.Length; z++)
        {
            for (int i = 0; i < wave.enemies[z].count; i++)
            {
                SpawnEnemy(wave.enemies[z].enemy);

                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
        }

        // Increase the waveIndex
        waveIndex++;
        Debug.Log("wave index: " + waveIndex + ". Should end at" + waves.Length);

    }

    // Spawns a new enemy on the spawnPoint
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
