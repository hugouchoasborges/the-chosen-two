using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    public int controllerNumber;

    // Controllers
    bool triggerHold = false;

    public string axisXAnalogStr;
    public string axisYAnalogStr;
    public string axisXDPadStr;
    public string axisYDPadStr;
    public string triggerAxisStr;
    public string rightBumperStr;
    public string leftBumperStr;
    public string aButtonStr;
    public string bButtonStr;
    public string xButtonStr;
    public string yButtonStr;

    // Components
    public Player player;

    #endregion


    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void SetControllerNumber(int number)
    {
        axisXAnalogStr = number + "_AnalogHorizontal";
        axisYAnalogStr = number + "_AnalogVertical";
        axisXDPadStr = number + "_DPadHorizontal";
        axisYDPadStr = number + "_DPadVertical";

        aButtonStr = number + "_A_Button";
        bButtonStr = number + "_B_Button";
        xButtonStr = number + "_X_Button";
        yButtonStr = number + "_Y_Button";

        leftBumperStr = number + "_Left_Bumper";
        rightBumperStr = number + "_Right_Bumper";
        triggerAxisStr = number + "_Trigger";

        controllerNumber = number;
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
        Animator animator = player.animator;
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        float axisX;
        float axisY;
        float trigger;
        bool rightBumper = false;
        bool leftBumper = false;
        bool aButtonPressed = false;
        bool bButtonPressed = false;
        bool xButtonPressed = false;
        bool yButtonPressed = false;

        if (player.isDead)
            return;

        // Captures player's input

        axisX = InputManager.Horizontal(this);

        axisY = InputManager.Vertical(this);
        aButtonPressed = InputManager.AButton(this);
        bButtonPressed = InputManager.BButton(this);
        xButtonPressed = InputManager.XButton(this);
        yButtonPressed = InputManager.YButton(this);

        leftBumper = InputManager.LeftBumper(this);
        rightBumper = InputManager.RightBumper(this);
        trigger = InputManager.Trigger(this);

        // ItemSwitching Buttons
        if (leftBumper)
        {
            player.inventory.PreviousItem();
            Debug.Log("LEFT BUMPEEER");
        }

        if (rightBumper)
        {
            player.inventory.NextItem();
            Debug.Log("RIGHT BUMPEEER");
            rightBumper = true;
        }

        if (!triggerHold && Mathf.Abs(trigger) > 0.5f)
        {
            Debug.Log("Trigger: " + trigger);
            triggerHold = true;
        }
        if (triggerHold && Mathf.Abs(trigger) < 0.6f)
        {
            triggerHold = false;
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
            if (!player.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("punch"))
            {
                player.punch();
            }
        }
        else if (bButtonPressed || yButtonPressed)
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
        if (controllerNumber > 0)
        {
            if (player && !player.drinking)
                HandleInput();
        }

        //if (player1.transform.position.y < player2.transform.position.y)
        //{
        //    player1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //    player2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        //}
        //else
        //{
        //    player2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //    player1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        //}
    }


}
