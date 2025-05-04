using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float bounceForce = 12f;
    public int health = 3;
    public int maxHealth = 3;
    public HealthDisplay healthDisplay;

    private Rigidbody2D rb;
    private int jumpCount = 0;
    public int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.UpdateHealth(health, maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;

        if (collision.collider.CompareTag("Obstacle"))
        {
            health = 0;
            healthDisplay.UpdateHealth(health, maxHealth);
            Die();
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            health--;
            Debug.Log("Hit by crocodile! Health: " + health);
            healthDisplay.UpdateHealth(health, maxHealth);

            rb.velocity = new Vector2(rb.velocity.x, bounceForce);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
