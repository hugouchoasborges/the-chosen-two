using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    private bool movementSet = false;
    private bool movementSet2 = false;

    #endregion

    private void SetAnimatorBool(Animator animator, string name, bool value)
    {
        if (animator.gameObject.name.Contains("2") && !movementSet2)
        {
            animator.SetBool(name, value);
            movementSet2 = true;
        }

        if (!animator.gameObject.name.Contains("2") && !movementSet)
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

    private void HandleInput(Player player)
    {
        Animator animator = player.animator;
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

        float axisX;
        float axisY;

        // Captures player's input
        if (player.name.Contains("2"))
        {
            axisX = InputManager.JMainHorizontal();
            axisY = InputManager.JMainVertical();
        }
        else
        {
            axisX = InputManager.KMainHorizontal();
            axisY = InputManager.KMainVertical();
        }

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

        // Player's movement vector
        Vector3 movement = GetMovementVector(axisX, axisY) * player.speed;

        // Move the player
        player.transform.Translate(movement * Time.deltaTime, Space.World);

        movementSet = false;
        movementSet2 = false;
    }

    private void Update()
    {
        if (GlobalVariables.player)
            HandleInput(GlobalVariables.player);
        if (GlobalVariables.player2)
            HandleInput(GlobalVariables.player2);
    }

}
