using UnityEngine;
using UnityEngine.Rendering;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;         // Gán prefab thạch nhũ vào đây
    public Transform spawnPoint;              // Vị trí xuất hiện (trên cao, bên phải màn hình)
   // public float spawnInterval = 2.5f;  
   public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    private float nextSpawnTime;// Thời gian giữa các lần sinh
    public float minY = 13.5f, maxY = 15f;        // Phạm vi ngẫu nhiên theo trục Y
    //public float minX 
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
            SpawnObstacle();
            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    void SpawnObstacle()
    {
        Vector3 position = spawnPoint.position;
        position.y = Random.Range(minY, maxY);    // Sinh ở vị trí y ngẫu nhiên trong khoảng

        Instantiate(obstaclePrefab, position, Quaternion.identity);
    }
}
