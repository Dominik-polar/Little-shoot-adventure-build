using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    private Transform target;
    public float speed = 4;
    private SpriteRenderer enemySprite;
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject enemy;
    public GameObject deathEffect;
    public float stoppingDistance;
    //public float retreatDistance;
    private float canShoot;
    public float timer;
    public GameObject bullet;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemySprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        /*if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * -speed);
        }*/
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance /*&& Vector2.Distance(transform.position, target.position) > retreatDistance*/)
        {
            transform.position = this.transform.position;
        }

        if(canShoot <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            canShoot = timer;
        }
        else
        {
            canShoot -= Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            Debug.Log("Player damage taken");
            //TUTAJ ZRÓB EFEKT KNOCKBACKA ZA POMOCĄ PARTICLES
        }

        /*if (other.CompareTag("Enemy"))
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }*/

        if (other.CompareTag("Bullet"))
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            StartCoroutine(Flash());
            TakeDamage();
            Debug.Log("Enemy hit by bullet");
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

    IEnumerator Flash()
    {
        for (int n = 0; n < 3; n++)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            yield return new WaitForSeconds(0.1f);
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

