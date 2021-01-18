using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int doorLocation;
    private int random;
    private RoomTemplate templates;
    private bool spawned = false;
    private float waitTime=5;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (spawned == false)
        {
            if (doorLocation == 2)
            {
                //Right rooms
                random = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
            }
            else if (doorLocation == 1)
            {
                //Left rooms
                random = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
            }
            else if (doorLocation == 4)
            {
                //Top rooms
                random = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);
            }
            else if (doorLocation == 3)
            {
                //Down rooms
                random = Random.Range(0, templates.downRooms.Length);
                Instantiate(templates.downRooms[random], transform.position, templates.downRooms[random].transform.rotation);
            }
                spawned = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if(spawned == false && other.GetComponent<RoomSpawner>().spawned == false)
            {
                Instantiate(templates.roomWithoutExit, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
       
        
    }
}
