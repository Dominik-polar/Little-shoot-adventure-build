using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private PlayerShooting shooting;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shooting = player.GetComponent<PlayerShooting>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player upgrade taken");
            if (shooting.attackDelay > 0.2f)
            {
                shooting.attackDelay = shooting.attackDelay - 0.1f;
            }
        }
    }
}
