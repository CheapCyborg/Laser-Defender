using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float ProjectileSpeed;
	public float firingRate;
	public float health = 250f;

	public GameObject Projectile;

	float rightBound = 8f;
	float leftBound = -8f;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		moveControls();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Attack", 0.00001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Attack");
		}
	}

	void moveControls()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		// Restrict the player to the game space
		float newX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void Attack()
	{
		Vector3 offset = new Vector3(0, 1, 0);
		GameObject beam = Instantiate(Projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, ProjectileSpeed, 0);
	}

	void Die()
	{
		Destroy(gameObject);
		LevelManager man = GameObject.Find("Level Manager").GetComponent<LevelManager>();
		man.LoadLevel("Win");
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
				Die();
			}
		}
	}
}