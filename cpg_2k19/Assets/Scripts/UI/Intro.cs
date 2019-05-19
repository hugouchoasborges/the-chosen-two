using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    #region Variables

    public List<Image> images;
    private int currentIndex;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }


    public void Next()
    {
        foreach (Image image in images)
        {
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
        for (int i = images.Count-1; i > 0; i--)
        {
            Image image = images[i];

            if (image.IsActive())
            {
                image.enabled = false;
                return;
            }
        }
        SceneManager.LoadScene("MainMenu");
    }
}
