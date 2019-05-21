using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    #region Controller 

    // -- Axis
    public static float JMainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float JMainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 JMainJoystick()
    {
        return new Vector3(JMainHorizontal(), 0, JMainVertical());
    }

    // -- Butons
    public static bool JAButton()
    {
        return Input.GetButtonDown("J_A_Button");
    }
    public static bool JBButton()
    {
        return Input.GetButtonDown("J_B_Button");
    }
    public static bool JXButton()
    {
        return Input.GetButtonDown("J_X_Button");
    }
    public static bool JYButton()
    {
        return Input.GetButtonDown("J_Y_Button");
    }

    #endregion

    #region Keyboard 1 

    // -- Axis
    public static float KMainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("K_MainHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float KMainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("K_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 KMainJoystick()
    {
        return new Vector3(KMainHorizontal(), 0, KMainVertical());
    }

    // -- Butons
    public static bool KAButton()
    {
        return Input.GetButtonDown("K_A_Button");
    }
    public static bool KBButton()
    {
        return Input.GetButtonDown("K_B_Button");
    }
    public static bool KXButton()
    {
        return Input.GetButtonDown("K_X_Button");
    }
    public static bool KYButton()
    {
        return Input.GetButtonDown("K_Y_Button");
    }

    #endregion

    #region Keyboard 2

    // -- Axis
    public static float K2MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("K2_MainHorizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float K2MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("K2_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 K2MainJoystick()
    {
        return new Vector3(K2MainHorizontal(), 0, K2MainVertical());
    }

    // -- Butons
    public static bool K2AButton()
    {
        return Input.GetButtonDown("K2_A_Button");
    }
    public static bool K2BButton()
    {
        return Input.GetButtonDown("K2_B_Button");
    }
    public static bool K2XButton()
    {
        return Input.GetButtonDown("K2_X_Button");
    }
    public static bool K2YButton()
    {
        return Input.GetButtonDown("K2_Y_Button");
    }

    #endregion
}
