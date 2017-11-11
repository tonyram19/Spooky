using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] float bumpForce;
	Rigidbody2D myBody;

	void Start () 
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Vector2 force = new Vector2(0, bumpForce);
			myBody.AddForce(force);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Obstacle")
		{
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<Animator>().Play("Explode");
		}
	}
}
