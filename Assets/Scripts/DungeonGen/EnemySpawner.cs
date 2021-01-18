using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private SpawnTrigger spawn;
    public GameObject trigger;
    private bool spawned = false;

    void Start()
    {
        spawn = trigger.GetComponent<SpawnTrigger>();
    }
    void Update()
    {
        if (spawn.playerTrigger == true && spawned == false)
        {
            Debug.Log("ENEMY SPAWN");
            Instantiate(enemy, transform.position, transform.rotation);
            spawned = true;
            Destroy(gameObject);
        }
    }
}
