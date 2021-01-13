using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth=5;
    public int currentHealth;
    public GameObject player;
    public GameObject deathEffect;
    private SpriteRenderer playerSprite;

    void Start()
    {
        currentHealth = maxHealth;
        playerSprite = this.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(Flash());
            TakeDamage();
            Debug.Log("Player damage taken");
        }

        if (other.CompareTag("EnemyBullet"))
        {
            StartCoroutine(Flash());
            TakeDamage();
            Debug.Log("Player damage taken");
        }
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 3; n++)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log("Health decreased");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
