using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAssigner : MonoBehaviour
{

    #region Variables

    public List<int> associatedControllers;

    #endregion


    public Player AddPlayerController(int controller)
    {
        if (associatedControllers.Contains(controller))
            return null;

        Player player1 = GlobalVariables.player1;
        Player player2 = GlobalVariables.player2;

        associatedControllers.Add(controller);

        if (player1.playerController.controllerNumber == 0)
        {
            player1.playerController.SetControllerNumber(controller);
            Debug.Log(string.Format("Controller {0} assigned to Player 1", controller));
            return player1;
        }
        else if (player2.playerController.controllerNumber == 0)
        {
            player2.playerController.SetControllerNumber(controller);
            Debug.Log(string.Format("Controller {0} assigned to Player 2", controller));
            return player2;
        }

        return null;
    }


    // Update is called once per frame
    void Update()
    {
        for(int i = 1; i <= 2; i++)
        {
            string input = "Joystick" + i + "_AnalogHorizontal";
            if (Mathf.Abs(Input.GetAxis(input)) > 0.5f)
            {
                AddPlayerController(i);
                break;
            }
        }
    }
}
