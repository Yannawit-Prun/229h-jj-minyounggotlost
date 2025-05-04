using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [Header("Heart Settings")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        Debug.Log("Updating health: " + currentHealth + "/" + maxHealth);

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Only show hearts up to maxHealth
            hearts[i].enabled = i < maxHealth;
        }
    }
}
