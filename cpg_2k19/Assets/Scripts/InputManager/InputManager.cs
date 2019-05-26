using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    #region Public Methods

    public static float Horizontal(PlayerController controller)
    {
        float r = 0.0f;
        r += Input.GetAxis("Joystick" + controller.axisXAnalogStr);
        r += Input.GetAxis("Joystick" + controller.axisXDPadStr);

        r += Input.GetAxis("Keyboard" + controller.axisXAnalogStr);
        r += Input.GetAxis("Keyboard" + controller.axisXDPadStr);

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float Vertical(PlayerController controller)
    {
        float r = 0.0f;
        r += Input.GetAxis("Joystick" + controller.axisYAnalogStr);
        r += Input.GetAxis("Joystick" + controller.axisYDPadStr);
                                                       
        r += Input.GetAxis("Keyboard" + controller.axisYAnalogStr);
        r += Input.GetAxis("Keyboard" + controller.axisYDPadStr);

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool AButton(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.aButtonStr)
            || Input.GetButtonDown("Keyboard" + controller.aButtonStr);
    }

    public static bool BButton(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.bButtonStr)
            || Input.GetButtonDown("Keyboard" + controller.bButtonStr);
    }

    public static bool XButton(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.xButtonStr)
            || Input.GetButtonDown("Keyboard" + controller.xButtonStr);
    }

    public static bool YButton(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.yButtonStr)
            || Input.GetButtonDown("Keyboard" + controller.yButtonStr);
    }

    public static bool LeftBumper(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.leftBumperStr)
            || Input.GetButtonDown("Keyboard" + controller.leftBumperStr);
    }

    public static bool RightBumper(PlayerController controller)
    {
        return Input.GetButtonDown("Joystick" + controller.rightBumperStr)
            || Input.GetButtonDown("Keyboard" + controller.rightBumperStr);
    }

    public static float Trigger(PlayerController controller)
    {
        float r = 0.0f;
        r += Input.GetAxis("Joystick" + controller.triggerAxisStr);

        r += Input.GetAxis("Keyboard" + controller.triggerAxisStr);

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    #endregion

}
