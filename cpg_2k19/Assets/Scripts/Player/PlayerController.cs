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

    private void HandleInput(Player player)
    {
        Animator animator = player.animator;
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        float axisX;
        float axisY;
        bool aButtonPressed1 = false;
        bool aButtonPressed2 = false;

        // Captures player's input
        if (player.name.Contains("2"))
        {
            axisX = InputManager.JMainHorizontal();
            axisY = InputManager.JMainVertical();
            aButtonPressed2 = InputManager.JAButton();
        }
        else
        {
            axisX = InputManager.KMainHorizontal();
            axisY = InputManager.KMainVertical();
            aButtonPressed1 = InputManager.KAButton();
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

        // Use item

        if (aButtonPressed1)
        {
            player.useItem();
        }

        if (aButtonPressed2)
        {
            player.useItem();
        }

        // Player's movement vector
        Vector3 movement = GetMovementVector(axisX, axisY) * player.speed;

        // Move the player
        player.transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        if (GlobalVariables.player)
            HandleInput(GlobalVariables.player);
        if (GlobalVariables.player2)
            HandleInput(GlobalVariables.player2);
    }

}
