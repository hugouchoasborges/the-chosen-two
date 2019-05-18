using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    #endregion

    public Vector3 GetMovementVector(float XAxis, float YAxis)
    {
        Vector3 _out = new Vector3(XAxis, YAxis);

        if (_out.magnitude > 1f)
            _out = _out.normalized;

        return _out;
    }

    private void HandleInput()
    {
        // Captures user's input
        float axisY = Input.GetAxis("Vertical");
        float axisX = Input.GetAxis("Horizontal");

        // Player's movement vector
        Vector3 movement = GetMovementVector(axisX, axisY) * GlobalVariables.player.speed;

        // Move the player
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        HandleInput();    
    }

}
