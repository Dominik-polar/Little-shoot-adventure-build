using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    private GameObject[] gameObjects;
    void Update()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Invoke("DestroyDoor", 1.0f);
    }

    void DestroyDoor()
    {
        if (gameObjects.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Enemy'. Opening door");
            Destroy(gameObject);
        }
    }
}
