using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int scoreValue = 10;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float destroyX = -20f;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 30f;

    void Update()
    {
        // Move left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Rotate slowly
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Destroy when out of bounds
        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Add score
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoints(10000);
            }

            // Destroy this target
            Destroy(gameObject);
        }
    }
}
