using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public float spawnInterval = 1.5f;
    public float spawnX = 10f;
    public float spawnY = -3f;
    public float moveSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGround();
            timer = 0f;
        }
    }

    void SpawnGround()
    {
        int index = Random.Range(0, groundPrefabs.Length);
        GameObject ground = Instantiate(groundPrefabs[index], new Vector2(spawnX, spawnY), Quaternion.identity);
        ground.AddComponent<MoveLeft>().speed = moveSpeed;
    }
}
