using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
