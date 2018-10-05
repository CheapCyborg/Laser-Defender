using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
	public float ProjectileSpeed;
	public float health;
	public float firingRate;
	public int scoreValue = 100;

	public AudioClip death;
	public GameObject Projectile;

	private scoreKeeper scoreKeeper;

	private void Start()
	{
		scoreKeeper = GameObject.Find("Score").GetComponent<scoreKeeper>();
	}

	void Update()
	{
		float probability = firingRate * Time.deltaTime;

		if (Random.value < probability)
		{
			Attack();
		}
	}

	void Attack ()
	{
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject beam = Instantiate(Projectile, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ProjectileSpeed, 0);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Projectile Missle = collision.gameObject.GetComponent<Projectile>();
		if (Missle)
		{
			health -= Missle.getDamage();
			Missle.hit();
			if (health < 0)
			{
				AudioSource.PlayClipAtPoint(death, transform.position);
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);
			}
		}
	}
}

	
