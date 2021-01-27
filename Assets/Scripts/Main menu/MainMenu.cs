using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("Deaths") == 0)
        {
            SceneManager.LoadScene("StartScene");
        }
        else
        {
            SceneManager.LoadScene("AgainScene");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
