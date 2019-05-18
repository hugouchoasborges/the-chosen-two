using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 GetMovementVector(float XAxis, float YAxis)
    {
        Vector3 _out = new Vector3(XAxis, YAxis);

        if (_out.magnitude > 1f)
            _out = _out.normalized;

        return _out;
    }

    private void HandleInput()
    {
        Player player = GlobalVariables.player;
        Animator animator = player.animator;

        // Captures user's input
        float axisY = Input.GetAxis("Vertical");
        float axisX = Input.GetAxis("Horizontal");


        // Horizontal Movement
        if(axisX == 0)
        {
            animator.SetBool("horizontal", false);
        }
        else if(axisX > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("horizontal", true);
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("horizontal", true);
        }

        // Vertical Movement
        if (axisY == 0)
        {
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        else if (axisY > 0)
        {
            animator.SetBool("up", true);
        }
        else
        {
            animator.SetBool("down", true);
        }

        // Player's movement vector
        Vector3 movement = GetMovementVector(axisX, axisY) * player.speed;

        // Move the player
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        HandleInput();    
    }

}
