using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script for preventing the player from jumping infinitely
public class PreventDoubleJump : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            PlayerMovement.doubleJumpAble = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement.doubleJumpAble = false;
    }
}
