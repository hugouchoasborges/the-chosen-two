using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    #region Joystick Player 1 

    // -- Axis
    public static float Joystick1Horizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("Joystick1_AnalogHorizontal");
        r += Input.GetAxis("Joystick1_DPadHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float Joystick1Vertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("Joystick1_AnalogVertical");
        r += Input.GetAxis("Joystick1_DPadVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 Joystick1Axis()
    {
        return new Vector3(Joystick1Horizontal(), Joystick1Vertical(), 0);
    }

    // -- Butons
    public static bool Joystick1AButton()
    {
        return Input.GetButtonDown("Joystick1_A_Button");
    }
    public static bool Joystick1BButton()
    {
        return Input.GetButtonDown("Joystick1_B_Button");
    }
    public static bool Joystick1XButton()
    {
        return Input.GetButtonDown("Joystick1_X_Button");
    }
    public static bool Joystick1YButton()
    {
        return Input.GetButtonDown("Joystick1_Y_Button");
    }

    #endregion

    #region Keyboard Player 1 

    // -- Axis
    public static float Keyboard1MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("Keyboard1_MainHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float Keyboard1MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("Keyboard1_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 Keyboard1Axis()
    {
        return new Vector3(Keyboard1MainHorizontal(), Keyboard1MainVertical(), 0);
    }

    // -- Butons
    public static bool Keyboard1AButton()
    {
        return Input.GetButtonDown("Keyboard1_A_Button");
    }
    public static bool Keyboard1BButton()
    {
        return Input.GetButtonDown("Keyboard1_B_Button");
    }
    public static bool Keyboard1XButton()
    {
        return Input.GetButtonDown("Keyboard1_X_Button");
    }
    public static bool Keyboard1YButton()
    {
        return Input.GetButtonDown("Keyboard1_Y_Button");
    }

    #endregion

    #region Keyboard Player 2 

    // -- Axis
    public static float Keyboard2MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("Keyboard2_MainHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float Keyboard2MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("Keyboard2_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 Keyboard2Axis()
    {
        return new Vector3(Keyboard2MainHorizontal(), Keyboard2MainVertical(), 0);
    }

    // -- Butons
    public static bool Keyboard2AButton()
    {
        return Input.GetButtonDown("Keyboard2_A_Button");
    }
    public static bool Keyboard2BButton()
    {
        return Input.GetButtonDown("Keyboard2_B_Button");
    }
    public static bool Keyboard2XButton()
    {
        return Input.GetButtonDown("Keyboard2_X_Button");
    }
    public static bool Keyboard2YButton()
    {
        return Input.GetButtonDown("Keyboard2_Y_Button");
    }

    #endregion
}
