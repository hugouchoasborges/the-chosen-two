using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float timeout;

    // Start is called before the first frame update
    void Start()
    {
        timeout = Time.time + 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeout && (!GlobalVariables.player1.isDamaged) && (!GlobalVariables.player2.isDamaged))
        {
            SecretEnding();
        }
        else
        {
            if (GlobalVariables.player1.isDead)
                RedVictory();
            else if (GlobalVariables.player2.isDead)
                BlueVictory();
        }
    }

    private void BlueVictory()
    {
        SceneManager.LoadScene("EndRedWins");
    }

    private void RedVictory()
    {
        SceneManager.LoadScene("EndBlueWins");
    }

    void SecretEnding ()
    {
        SceneManager.LoadScene("EndHappy");
    }
}
