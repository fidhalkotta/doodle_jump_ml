using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	[SerializeField] private float movementSpeed = 10f;
	[SerializeField] private float levelWidth = 3f;

	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
	}

	private void FixedUpdate()
	{
		var velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;

		if (transform.position.x < -levelWidth)
		{
			transform.position = new Vector3(levelWidth, transform.position.y,transform.position.z);
		}
		else if (transform.position.x > levelWidth)
		{
			transform.position = new Vector3(-levelWidth, transform.position.y,transform.position.z);
		}
	}
}
