using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public SpriteRenderer heart1;
    public SpriteRenderer heart2;
    public SpriteRenderer heart3;
    public SpriteRenderer heart4;
    public SpriteRenderer heart5;
    private PlayerHealth health;
    public Sprite brokenHeart;
    public GameObject player;

    void Start()
    {
        health = player.GetComponent<PlayerHealth>();
    }


    void Update()
    {
        if (health.currentHealth <= 4)
        {
            heart5.sprite = brokenHeart;
        }
        if (health.currentHealth <= 3)
        {
            heart4.sprite = brokenHeart;
        }
        if (health.currentHealth <= 2)
        {
            heart3.sprite = brokenHeart;
        }
        if (health.currentHealth <= 1)
        {
            heart2.sprite = brokenHeart;
        }
        if (health.currentHealth <= 0)
        {
            heart1.sprite = brokenHeart;
        }

    }

}
