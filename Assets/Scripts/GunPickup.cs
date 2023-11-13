using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject playerWithGunPrefab; // The player with the gun prefab

    private void Update()
    {
        // Check for the "E" key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    PickUpGun(collider.gameObject);
                    break;
                }
            }
        }
    }

    void PickUpGun(GameObject player)
    {
        // Instantiate the player with the gun prefab at the player's position
        GameObject playerWithGun = Instantiate(playerWithGunPrefab, player.transform.position, Quaternion.identity);

        // Destroy the original player
        Destroy(player);

        // You might want to customize the new player's position and rotation based on the original player's state

        // Optional: Transfer any necessary player data from the old player to the new one (e.g., health, score, etc.)

        // Destroy the gun pickup object
        Destroy(gameObject);
    }
}
