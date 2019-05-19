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
        bool aButtonPressed = false;

        // Captures player's input
        if (player.name.Contains("2"))
        {
            axisX = InputManager.JMainHorizontal();
            axisY = InputManager.JMainVertical();
            aButtonPressed = InputManager.JAButton();
        }
        else
        {
            axisX = InputManager.KMainHorizontal();
            axisY = InputManager.KMainVertical();
            aButtonPressed = InputManager.KAButton();
        }

        // Horizontal Movement
        if (axisX > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("horizontal", true);
            player.facingDir = 3;
        }
        else if (axisX < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("horizontal", true);
            player.facingDir = 1;
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
            player.facingDir = 2;
        }
        else
        {
            animator.SetBool("down", true);
            player.facingDir = 0;
        }

        // 8 Dir orentation
        if (axisY < 0 && axisX < 0)
        {
            player.facingDir8 = 1;
        }
        else if (axisY == 0 && axisX < 0)
        {
            player.facingDir8 = 2;
        }
        else if (axisY > 0 && axisX < 0)
        {
            player.facingDir8 = 3;
        }
        else if (axisY > 0 && axisX == 0)
        {
            player.facingDir8 = 4;
        }
        else if (axisY > 0 && axisX > 0)
        {
            player.facingDir8 = 5;
        }
        else if (axisY == 0 && axisX > 0)
        {
            player.facingDir8 = 6;
        }
        else if (axisY < 0 && axisX > 0)
        {
            player.facingDir8 = 7;
        }
        else if (axisX < 0 && axisX == 0)
        {
            player.facingDir8 = 0;
        }

        // Use item

        if (aButtonPressed)
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
        Player player1 = GlobalVariables.player;
        Player player2 = GlobalVariables.player2;

        if (player1)
            HandleInput(player1);
        if (player2)
            HandleInput(player2);

        if (player1.transform.position.y < player2.transform.position.y)
        {
            player1.GetComponent<SpriteRenderer>().sortingOrder = 1;
            player2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            player2.GetComponent<SpriteRenderer>().sortingOrder = 1;
            player1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

}
