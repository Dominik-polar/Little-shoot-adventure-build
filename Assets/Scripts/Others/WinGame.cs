using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private GameObject[] gameObjects;
    public int wins;
    public int highscore;
    private PlayerScore score;
    public GameObject count;


    void Start()
    {
        count = GameObject.FindGameObjectWithTag("Score");
        score = count.GetComponent<PlayerScore>();
    }

    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

 
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObjects.Length == 0)
        {
            highscore = 0;
            wins = 0;

            wins++;
            wins = PlayerPrefs.GetInt("Wins") + wins;
            PlayerPrefs.SetInt("Wins", wins);

            highscore = PlayerPrefs.GetInt("Kills") + score.killedEnemy;
            PlayerPrefs.SetInt("Kills", highscore);
            Debug.Log(PlayerPrefs.GetInt("Kills").ToString());

            SceneManager.LoadScene("WinScene");
            Debug.Log("You won!");
        }
    }

    
}
