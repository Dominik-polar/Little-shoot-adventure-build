using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth=5;
    public int currentHealth;
    public GameObject player;
    public GameObject deathEffect;
    private SpriteRenderer playerSprite;
    public Collider2D playerTrigger;
    private PlayerScore score;
    public GameObject count;
    public int highscore;
    public int deaths;

    void Start()
    {
        currentHealth = maxHealth;
        playerSprite = this.GetComponent<SpriteRenderer>();
        score = count.GetComponent<PlayerScore>();
        highscore = 0;
        deaths = 0;
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
        playerTrigger.enabled = false;
        for (int n = 0; n < 3; n++)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        playerTrigger.enabled = true;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log("Health decreased");
        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        highscore = PlayerPrefs.GetInt("Kills") + score.killedEnemy;
        PlayerPrefs.SetInt("Kills", highscore);
        Debug.Log(PlayerPrefs.GetInt("Kills").ToString());

        deaths++;
        deaths = PlayerPrefs.GetInt("Deaths") + deaths;
        PlayerPrefs.SetInt("Deaths", deaths);
        Debug.Log(PlayerPrefs.GetInt("Deaths").ToString());

        SceneManager.LoadScene("GameOver");
        
    }
}
