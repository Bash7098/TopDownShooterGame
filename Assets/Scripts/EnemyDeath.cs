using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int health = 3; // Adjust the initial health as needed

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Assuming bullets have a script called Bullet that handles damage
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet != null)
            {
                // Subtract bullet damage from enemy health
                health -= bullet.damage;

                // Check if the enemy has no health left
                if (health <= 0)
                {
                    // Perform disappearance logic
                    Destroy(gameObject);
                }
            }
        }
    }
}
