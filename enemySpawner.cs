using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	public GameObject Projectile;

	float rightBound = 7f;
	float leftBound = -7f;
	private bool movingRight = true;

	// Use this for initialization
	void Start ()
	{
		spawnUntilFull();
	}

	// Update is called once per frame
	void Update()
	{
		if (movingRight)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);

		if (leftEdgeOfFormation < leftBound)
		{
			movingRight = true;
		}
		else if (rightEdgeOfFormation > rightBound)
		{
			movingRight = false;
		}

		if (allMembersDead())
		{
			Debug.Log("Empty Formation");
			spawnUntilFull();
		}
	}

	private void spawnEnemies()
	{
		foreach (Transform child in transform)
		{
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	void spawnUntilFull()
	{
		Transform freePosition = nextFreePosition();
		if (freePosition)
		{
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if (nextFreePosition())
		{
			Invoke("spawnUntilFull", spawnDelay);
		}
	}

	Transform nextFreePosition()
	{
		foreach (Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount == 0)
			{
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool allMembersDead()
	{
		foreach(Transform childPositionGameObject in transform)
		{
			 if (childPositionGameObject.childCount > 0)
			{
				return false;
			}
		}
		return true;
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

}
