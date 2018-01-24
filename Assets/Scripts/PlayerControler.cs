using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public Text score;
	public Text winText;
	private Rigidbody rb;
	public float speed;
	private int count;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		UpdateScore();
		winText.text = "";
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			UpdateScore();
			if(count == 8)
			{
				winText.text = "Get soced!";
			}
		}
	}

	void UpdateScore()
	{
		score.text = "Score : " + count;
	}

}
