using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float timeout;

    // Start is called before the first frame update
    void Start()
    {
        timeout = Time.time + 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeout && (!GlobalVariables.player.isDamaged) && (!GlobalVariables.player2.isDamaged))
        {
            SecretEnding();
        }
        else
        {
            if (GlobalVariables.player.isDead)
                RedVictory();
            else if (GlobalVariables.player2.isDead)
                BlueVictory();
        }
    }

    private void BlueVictory()
    {
        Debug.Log("Blue Wins!");
    }

    private void RedVictory()
    {
        Debug.Log("Red Wins!");
    }

    void SecretEnding ()
    {
        Debug.Log("Secret Ending triggered!");
    }
}
