using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Adjust the damage value as needed

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet when it hits something
        Destroy(gameObject);
    }
}
