using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(transform.right * speed);
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			DestroyBullet();
			Debug.Log("Enemy damage taken");
		}
		if (other.CompareTag("Obstacle"))
		{
			DestroyBullet();
			Debug.Log("Obstacle detected");
		}
	}

	void OnBecameInvisible()
	{
		Debug.Log("Invisible bullet");
		DestroyBullet();
	}

	void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
