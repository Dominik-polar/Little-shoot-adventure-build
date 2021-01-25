using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private GameObject[] gameObjects;
    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

 
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObjects.Length == 0)
        {
            SceneManager.LoadScene("WinScene");
            Debug.Log("You won!");
        }
    }

    
}
