using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;     // Prefabs to spawn (trampoline, cactus, etc.)
    public float minSpawnRate = 3f;          // Min time between spawns
    public float maxSpawnRate = 10f;          // Max time between spawns
    public float spawnX = 10f;               // X position to spawn
    public float spawnY = -2f;                // Fixed Y position
    public float spawnZ = -2f;
    public float moveSpeed = 5f;             // Movement speed of obstacles

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            ScheduleNextSpawn();
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);  // Pick a random prefab
        Vector2 spawnPosition = new Vector3(spawnX, spawnY, spawnZ);  // Fixed Y

        GameObject obstacle = Instantiate(obstaclePrefabs[index], spawnPosition, Quaternion.identity);
        obstacle.AddComponent<MoveLeft>().speed = moveSpeed;  // Add movement
    }

    void ScheduleNextSpawn()
    {
        float spawnDelay = Random.Range(minSpawnRate, maxSpawnRate);  // Random timing
        nextSpawnTime = Time.time + spawnDelay;
    }
}

// Handles movement and destruction
public class MoveLeft : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
