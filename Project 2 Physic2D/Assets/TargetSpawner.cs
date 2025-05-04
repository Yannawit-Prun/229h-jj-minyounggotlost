using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxTargets = 5;

    [Header("Spawn Area")]
    [SerializeField] private Vector2 minPosition = new Vector2(-8, -4);
    [SerializeField] private Vector2 maxPosition = new Vector2(8, 4);

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && CountCurrentTargets() < maxTargets)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    void SpawnTarget()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y)
        );

        Instantiate(targetPrefab, spawnPos, Quaternion.identity);
    }

    int CountCurrentTargets()
    {
        return GameObject.FindGameObjectsWithTag("Target").Length;
    }
}
