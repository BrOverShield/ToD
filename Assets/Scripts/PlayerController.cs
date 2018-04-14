using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10;
	private Rigidbody rb;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float inputHorizontal = Input.GetAxis("Horizontal") * speed;
		float inputVertical = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3(inputHorizontal, 0.0f, inputVertical);

		rb.AddForce(movement);
	}
}
