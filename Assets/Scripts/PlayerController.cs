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
    GameObject pickuper;
	public float impulseForce = 5;
	private Vector3 impulse;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
		impulse = new Vector3(0.0f, impulseForce, 0.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float inputHorizontal = Input.GetAxis("Horizontal") * speed;
		float inputVertical = Input.GetAxis("Vertical") * speed;

		if(Input.GetKeyDown("space"))
		{
			rb.AddForce(impulse, ForceMode.Impulse);
		}
		else
		{
			Vector3 mouvement = new Vector3(inputHorizontal, 0.0f, inputVertical);
			rb.AddForce(mouvement);
		}


        //if(Vector3.Distance(this.transform.position,pickuper.transform.position)<=0.2)
        //{
            //pickuper.SetActive(false);
            //count++;
            //setCountText();
        //}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
            pickit(other);
		}
		else if (other.gameObject.CompareTag("Trap"))
		{
			other.gameObject.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
			other.gameObject.tag = "Untagged";
			Debug.Log("touche");
		}
	}
    void pickit(Collider other)
    {
        other.gameObject.SetActive(false);
        count++;
        setCountText();
    }
	void setCountText ()
	{
		//countText.text = "Count: " + count.ToString ();
	}
}


