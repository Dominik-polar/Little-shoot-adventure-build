using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenu;

    public Text score;

    void Start()
    {
        score.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);

        score.GetComponent<Text>().enabled = false;

        Time.timeScale = 1f;

        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);

        score.GetComponent<Text>().enabled = true;

        Time.timeScale = 0f;

        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene("MenuScene");
        Resume();
    }

    public void ResumeGame()
    {
        Resume();
    }
}
