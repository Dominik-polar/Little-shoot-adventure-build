using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
	void OnBecameInvisible()
	{
		Debug.Log("Invisible particle");
		DestroyParticles();
	}

	void DestroyParticles()
	{
		Destroy(gameObject);
	}
}
