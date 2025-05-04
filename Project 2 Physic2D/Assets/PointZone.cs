using UnityEngine;

public class PointZone : MonoBehaviour
{
    private bool hasScored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasScored && other.CompareTag("Player"))
        {
            hasScored = true;
            ScoreManager.instance.AddPoints(1000);
        }
    }
}
