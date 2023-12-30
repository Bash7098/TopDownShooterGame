using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public float interactionRange = 2f; // Adjust the interaction range as needed
    public LayerMask interactableLayer; // Assign the layer for interactable objects in the Inspector

    private GameObject pickedObject;
    private Transform carryPosition; // Position to carry the object relative to the player

    void Start()
    {
        // Create an empty GameObject as a child to represent the carry position
        carryPosition = new GameObject("CarryPosition").transform;
        carryPosition.SetParent(transform);
        carryPosition.localPosition = new Vector3(1.3f, 0f, 0f); // Adjust the position as needed
    }

    void Update()
    {
        // Check if the player presses the "Q" key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Toggle between picking up and dropping an object
            if (pickedObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        // If an object is picked up, move it with the player
        if (pickedObject != null)
        {
            MovePickedObject();
        }
    }

    void TryPickUpObject()
    {
        // Check for nearby interactable objects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer);

        // Pick up the first found object (if any)
        foreach (var collider in colliders)
        {
            // Make sure the object is not already picked up
            if (collider.gameObject != pickedObject)
            {
                PickUpObject(collider.gameObject);
                break;
            }
        }
    }

    void PickUpObject(GameObject obj)
    {
        // Attach the object to the carry position
        obj.transform.SetParent(carryPosition);
        obj.transform.localPosition = Vector3.zero;

        // Set the picked object
        pickedObject = obj;
    }

    void DropObject()
    {
        // Detach the object from the carry position
        pickedObject.transform.SetParent(null);

        // Reset the picked object
        pickedObject = null;
    }

    void MovePickedObject()
    {
        // Move the picked object to the carry position
        pickedObject.transform.position = carryPosition.position;
    }

    // For visualization purposes, you can draw the interaction range in the scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
