using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 1; // Amount of health restored when picked up

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the player collides with the heal item
        if (collider.CompareTag("Player"))
        {
            // Get the PlayerController component from the player
            PlayerController playerController = collider.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Heal the player and update the health display
                playerController.health = Mathf.Min(playerController.health + healAmount, playerController.maxHealth);
                playerController.healthDisplay.UpdateHealth(playerController.health, playerController.maxHealth);

                // Destroy the heal item after being picked up
                Destroy(gameObject);
            }
        }
    }
}
