using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    [Header("Enemy Spawner Settings")]
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    public float enemyMinSpawnTime = 1f;
    public float enemyMaxSpawnTime = 3f;
    public float enemyMinX = 13.5f, enemyMaxX = 15f;

    [Header("Obstacle Spawner Settings")]
    public GameObject obstaclePrefab;
    public Transform obstacleSpawnPoint;
    public float obstacleMinSpawnTime = 1f;
    public float obstacleMaxSpawnTime = 1.75f;
    public float obstacleMinY = 13.5f, obstacleMaxY = 15f;

    private float enemyTimer = 0f;
    private float nextEnemySpawnTime;

    private float obstacleTimer = 0f;
    private float nextObstacleSpawnTime;

    private bool isSpawning = true;

    void Start()
    {
        ResetSpawner();
    }

    void Update()
    {
        if (!isSpawning) return;

        // Enemy Spawn
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= nextEnemySpawnTime)
        {
            SpawnEnemy();
            enemyTimer = 0f;
            nextEnemySpawnTime = Random.Range(enemyMinSpawnTime, enemyMaxSpawnTime);
        }

        // Obstacle Spawn
        obstacleTimer += Time.deltaTime;
        if (obstacleTimer >= nextObstacleSpawnTime)
        {
            SpawnObstacle();
            obstacleTimer = 0f;
            nextObstacleSpawnTime = Random.Range(obstacleMinSpawnTime, obstacleMaxSpawnTime);
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null || enemySpawnPoint == null) return;

        Vector3 position = enemySpawnPoint.position;
        position.x = Random.Range(enemyMinX, enemyMaxX);
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    public void SpawnObstacle()
    {
        if (obstaclePrefab == null || obstacleSpawnPoint == null) return;

        Vector3 position = obstacleSpawnPoint.position;
        position.y = Random.Range(obstacleMinY, obstacleMaxY);
        Instantiate(obstaclePrefab, position, Quaternion.identity);
    }

    public void ResetSpawner()
    {
        enemyTimer = 0f;
        nextEnemySpawnTime = Random.Range(enemyMinSpawnTime, enemyMaxSpawnTime);

        obstacleTimer = 0f;
        nextObstacleSpawnTime = Random.Range(obstacleMinSpawnTime, obstacleMaxSpawnTime);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }
}
