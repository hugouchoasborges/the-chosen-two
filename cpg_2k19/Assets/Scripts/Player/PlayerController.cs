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
        bool bButtonPressed = false;
        bool xButtonPressed = false;
        bool yButtonPressed = false;

        if (player.isDead)
            return;

        // Captures player's input
        if (player.name.Contains("2"))
        {
            // PLAYER 2
            float horizontalAxisEntry = InputManager.Joystick1Horizontal() + InputManager.Keyboard2MainHorizontal();
            axisX = Mathf.Clamp(horizontalAxisEntry, -1f, 1f);

            float verticalAxisEntry = InputManager.Joystick1Vertical() + InputManager.Keyboard2MainVertical();
            axisY = Mathf.Clamp(verticalAxisEntry, -1f, 1f);
            aButtonPressed = InputManager.Joystick1AButton() || InputManager.Keyboard2AButton();
            bButtonPressed = InputManager.Joystick1BButton() || InputManager.Keyboard2BButton();
            xButtonPressed = InputManager.Joystick1XButton() || InputManager.Keyboard2XButton();
            yButtonPressed = InputManager.Joystick1YButton() || InputManager.Keyboard2YButton();
        }
        else
        {
            // PLAYER 1
            axisX = InputManager.Keyboard1MainHorizontal();
            axisY = InputManager.Keyboard1MainVertical();
            aButtonPressed = InputManager.Keyboard1AButton();
            bButtonPressed = InputManager.Keyboard1BButton();
            xButtonPressed = InputManager.Keyboard1XButton();
            yButtonPressed = InputManager.Keyboard1YButton();
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

        if (aButtonPressed || xButtonPressed)
        {
            player.punch();
        } else if (bButtonPressed || yButtonPressed)
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

        if (player1 && !player1.drinking)
            HandleInput(player1);
        if (player2 && !player2.drinking)
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
