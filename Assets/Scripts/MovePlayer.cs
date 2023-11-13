using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;


    private void Awake()
    {
        if (movementJoystick == null)
        {
            GameObject tempJoy = GameObject.FindGameObjectWithTag("Joystick_Control");
            movementJoystick = tempJoy.GetComponent<MovementJoystick>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            movementDirection = new Vector2(movementJoystick.joystickVec.x, movementJoystick.joystickVec.y).normalized;
            rb.velocity = movementDirection * playerSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        // Update the character's rotation based on the movement direction
        if (movementDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
