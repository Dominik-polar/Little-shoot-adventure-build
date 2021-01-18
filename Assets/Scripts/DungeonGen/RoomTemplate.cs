using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject[] topRooms;
    public GameObject[] downRooms;
    public float waitTime;
    private bool spawned = false;
    public GameObject exitTraining;
    public GameObject roomWithoutExit;

    public List<GameObject> rooms;

    void Update()
    {
        if(waitTime <= 0 && spawned == false)
        {
            for(int i=0; i<= rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(exitTraining, rooms[i].transform.position, Quaternion.identity);
                    spawned = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
