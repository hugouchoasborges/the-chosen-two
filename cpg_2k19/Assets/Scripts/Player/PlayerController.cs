using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    private bool movementSet = false;

    #endregion

    private void SetAnimatorBool(Animator animator, string name, bool value)
    {
        if (!movementSet)
        {
            animator.SetBool(name, value);
            movementSet = true;
        }
    }

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
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();


        // Captures user's input
        float axisY = Input.GetAxis("Vertical");
        float axisX = Input.GetAxis("Horizontal");

        // Player's movement vector
        Vector3 movement = GetMovementVector(axisX, axisY) * player.speed;

        // Diagonal Movement
        if (axisX != 0 && axisY > 0.2f)
        {
            animator.SetBool("diag_up", true);
            animator.SetBool("diag_down", false);
        }
        else if (axisX != 0 && axisY < -0.2f)
        {
            animator.SetBool("diag_up", false);
            animator.SetBool("diag_down", true);
        }
        else
        {
            animator.SetBool("diag_up", false);
            animator.SetBool("diag_down", false);
        }

        // Horizontal Movement
        if (axisX > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("horizontal", true);
        }
        else if (axisX < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("horizontal", true);
        }
        else
        {
            animator.SetBool("horizontal", false);
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

        // Move the player
        transform.Translate(movement * Time.deltaTime, Space.World);

        movementSet = false;
    }

    private void Update()
    {
        HandleInput();
    }

}
