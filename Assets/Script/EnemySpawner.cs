using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public GameObject enemy;        
    public Transform spawnPoint;             
                                             
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    private float nextSpawnTime;
    public float minX = 13.5f, maxX = 15f;       
   
    private float timer;

    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            SpawnEnemy();
            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

   public void SpawnEnemy()
    {
        Vector3 position = spawnPoint.position;
        position.x = Random.Range(minX, maxX);  

        Instantiate(enemy, position, Quaternion.identity);
    }
}
