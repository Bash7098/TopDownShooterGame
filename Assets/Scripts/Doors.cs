using UnityEngine;

public class Doors : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust the interaction distance as needed

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the "F" key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Check if the player is near the object
            if (IsPlayerNear())
            {
                // Perform destruction logic
                DestroyObject();
            }
        }
    }

    bool IsPlayerNear()
    {
        // Find the player GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Check the distance between the player and this GameObject
            float distance = Vector3.Distance(transform.position, player.transform.position);
            return distance <= interactionDistance;
        }

        return false;
    }

    void DestroyObject()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }
}
