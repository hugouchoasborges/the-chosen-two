using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    #region Variables

    public List<Image> images;

    public Text nextButtonText;
    public Text previousButtonText;

    public AudioSource audioSource;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Next()
    {
        audioSource.Play();

        for (int i = 0; i < images.Count; i++)
        {
            Image image = images[i];
            if (i == (images.Count - 1))
            {
                nextButtonText.text = "Jogar";
            }
            else
            {
                nextButtonText.text = "Próximo";
            }

            if (i == 1)
            {
                previousButtonText.text = "Menu";
            }
            else
            {
                previousButtonText.text = "Anterior";
            }

            if (!image.IsActive())
            {
                image.enabled = true;
                return;
            }
        }

        SceneManager.LoadScene("Game");
    }

    public void Previous()
    {
        audioSource.Play();

        for (int i = images.Count - 1; i > 0; i--)
        {
            Image image = images[i];

            if (i == (images.Count))
            {
                nextButtonText.text = "Jogar";
            }
            else
            {
                nextButtonText.text = "Próximo";
            }

            if (i == 0)
            {
                previousButtonText.text = "Menu";
            }
            else
            {
                previousButtonText.text = "Anterior";
            }

            if (image.IsActive())
            {
                image.enabled = false;
                return;
            }
        }
        SceneManager.LoadScene("MainMenu");
    }
}
