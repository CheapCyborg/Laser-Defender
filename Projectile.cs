using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage = 100f;

	public void hit()
	{
		Destroy(gameObject);
	}

	public float getDamage()
	{
		return damage;
	}
}
