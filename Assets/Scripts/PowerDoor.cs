using UnityEngine;
using System.Collections.Generic;

public class ObjectDestroyer : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust the interaction distance as needed
    public List<GameObject> objectsToDestroy = new List<GameObject>(); // List of objects to destroy

    void Update()
    {
        // Check if the player presses the "F" key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Check if the player is near the object
            if (IsPlayerNear())
            {
                // Perform destruction logic
                DestroyObjects();
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

    void DestroyObjects()
    {
        // Destroy each specified object in the list
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null) // Check if the object is not already destroyed
            {
                Destroy(obj);
            }
        }

        // Clear the list after destroying objects (optional)
        objectsToDestroy.Clear();
    }
}
