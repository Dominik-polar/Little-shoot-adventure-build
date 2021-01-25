using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
