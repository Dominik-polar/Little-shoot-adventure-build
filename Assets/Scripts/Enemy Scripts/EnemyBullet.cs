﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	private Transform player;
	private Vector2 target;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

		if(target.x == transform.position.x && target.y == transform.position.y)
        {
			DestroyBullet();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			DestroyBullet();
			Debug.Log("Player damage taken");
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
