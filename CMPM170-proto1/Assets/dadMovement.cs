using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadMovement : MonoBehaviour
{
    public Rigidbody2D dadBod;
    public float moveSpeed;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        dadBod.MovePosition(dadBod.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
