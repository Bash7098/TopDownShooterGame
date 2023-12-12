using UnityEngine;

public class ShootgunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float bulletForce = 20f;
    public float fireRate = 1f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Check for the spacebar key press and fire rate
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Update the next fire time based on the fire rate
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            // Instantiate a bullet at the fire point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Apply force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}
