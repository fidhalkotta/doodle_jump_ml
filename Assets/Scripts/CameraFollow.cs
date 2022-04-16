using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	private Vector3 startingPos;
	private void Awake()
	{
		startingPos = transform.position;
	}

	public void ResetCamera()
	{
		transform.position = startingPos;
	}

	private void LateUpdate () {
		if (target.position.y > transform.position.y)
		{
			var newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = newPos;
		}
	}
}
