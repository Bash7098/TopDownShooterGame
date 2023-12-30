using UnityEngine;

public class Trap : MonoBehaviour
{
    public float cooldownTime = 30f;
    private float cooldownTimer = 0f;

    private void Update()
    {
        // Update cooldown timer
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;

            // Change color to red when on cooldown
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            // Change color to green when ready
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Check if the cooldown is complete
            if (cooldownTimer <= 0f)
            {
                // Destroy the enemy
                Destroy(other.gameObject);

                // Start the cooldown
                cooldownTimer = cooldownTime;
            }
        }
    }
}
