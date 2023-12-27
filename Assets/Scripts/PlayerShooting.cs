using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    public GunReloader gunReloader; // Reference to the GunReloader script

    void Update()
    {
        // Check for the spacebar key press and fire rate
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            if (gunReloader.TryShoot())
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate; // Update the next fire time based on the fire rate
            }
        }
    }

    void Shoot()
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
