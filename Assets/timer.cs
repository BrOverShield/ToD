using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	public float time = 60;
	public Text timerText;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		time -= Time.deltaTime;
		updateTimer();
		if (time <= 0)
		{
			SceneManager.LoadScene("Decision01");
		}
	}

	void updateTimer ()
	{
		timerText.text = time.ToString ();
	}
}
