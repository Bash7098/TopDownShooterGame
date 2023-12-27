using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        // If you have a health bar UI, update its values
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1); // Adjust the damage as needed
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // If you have a health bar UI, update its value
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can add death logic here (e.g., respawn the player)
        // For now, let's just deactivate the player
        gameObject.SetActive(false);
    }
}
