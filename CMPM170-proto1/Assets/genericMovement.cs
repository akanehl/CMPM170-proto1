using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericMovement : MonoBehaviour
{
    public Rigidbody2D dadBod;
    public float moveSpeed;

    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right; 

    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        movement.x = 0;
        movement.y = 0;
        if(Input.GetKey(left) && !Input.GetKey(right))
        {
            movement.x = -1;
        }
        if (Input.GetKey(right) && !Input.GetKey(left))
        {
            movement.x = 1;
        }
        if (Input.GetKey(forward) && !Input.GetKey(backward))
        {
            movement.y = 1;
        }
        if (Input.GetKey(backward) && !Input.GetKey(forward))
        {
            movement.y = -1;
        }

    }

    private void FixedUpdate()
    {
        dadBod.MovePosition(dadBod.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
