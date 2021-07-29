using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script for allowing the player to move
public class PlayerMovement : MonoBehaviour
{

    float speed = 2f;
    Rigidbody2D rb;
    Vector3 startingPosition;

    public static bool doubleJumpAble;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal");  
        var movement = input * speed;

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && doubleJumpAble == true)
        {
            rb.AddForce(new Vector3(0, 300, 0));
        }
    }
}
