using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 10;
	private Rigidbody rb;
	private int count;
	public Text countText;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float inputHorizontal = Input.GetAxis("Horizontal") * speed;
		float inputVertical = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3(inputHorizontal, 0.0f, inputVertical);

		rb.AddForce(movement);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
	}

	void setCountText ()
	{
		countText.text = "Count: " + count.ToString ();
	}
}


