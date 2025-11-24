using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
    public string waveName;
    public GameObject[] enemies;
    public float spawnInterval;
    public int enemyCount;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    public Transform[] spawnPoints;
    public List<Wave> waves;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private float spawnTimer;
    private int enemiesSpawnedInWave = 0;
    private bool isWaitingForWave = false;
    private float waveCooldownTimer;

    // Difficulty scaling
    private float difficultyMultiplier = 1.0f;

    public static EnemySpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (waves.Count == 0)
        {
            Debug.LogWarning("No waves defined in EnemySpawner!");
            return;
        }

        StartWave(0);
    }

    void Update()
    {
        if (waves.Count == 0) return;

        if (isWaitingForWave)
        {
            waveCooldownTimer -= Time.deltaTime;
            if (waveCooldownTimer <= 0)
            {
                NextWave();
            }
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnEnemy();
        }
    }

    void StartWave(int index)
    {
        currentWaveIndex = index;
        enemiesSpawnedInWave = 0;
        isWaitingForWave = false;

        Wave currentWave = waves[currentWaveIndex];
        spawnTimer = currentWave.spawnInterval / difficultyMultiplier; // Apply difficulty

        Debug.Log($"Starting Wave: {currentWave.waveName}");
        // Notify UI if possible (GameManager event)
    }

    void SpawnEnemy()
    {
        Wave currentWave = waves[currentWaveIndex];

        if (enemiesSpawnedInWave >= currentWave.enemyCount)
        {
            // Wave complete
            isWaitingForWave = true;
            waveCooldownTimer = timeBetweenWaves;
            Debug.Log("Wave Complete! Waiting for next wave...");
            return;
        }

        // Pick random enemy from wave config
        if (currentWave.enemies.Length > 0 && spawnPoints.Length > 0)
        {
            GameObject enemyPrefab = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            enemiesSpawnedInWave++;
            spawnTimer = currentWave.spawnInterval / difficultyMultiplier;
        }
    }

    void NextWave()
    {
        int nextIndex = currentWaveIndex + 1;
        if (nextIndex < waves.Count)
        {
            StartWave(nextIndex);
        }
        else
        {
            // Loops the last wave but harder? Or just endless mode
            Debug.Log("All waves complete! Increasing difficulty and looping last wave.");
            difficultyMultiplier += 0.2f; // Make it 20% faster
            StartWave(currentWaveIndex); // Restart last wave with higher difficulty
        }
    }
}
