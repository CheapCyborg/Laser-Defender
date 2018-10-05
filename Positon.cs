using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positon : MonoBehaviour
{
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
