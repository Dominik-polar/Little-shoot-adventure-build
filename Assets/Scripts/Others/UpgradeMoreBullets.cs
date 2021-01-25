using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMoreBullets : MonoBehaviour
{
    private PlayerShooting shooting;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shooting = player.GetComponent<PlayerShooting>();
    }

    void Update()
    {
        if(shooting.firesecondbullet == true)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player upgrade taken");
            shooting.firesecondbullet = true;
        }
    }


}
