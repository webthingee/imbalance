using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

	Transform plyer;

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log("FALL");
		// get and disable the collider on the line
		GameObject.Find("Line").GetComponent<EdgeCollider2D>().enabled = false;
		// set the player transform
		plyer = GameObject.Find("Player").GetComponent<Transform>();
		if (plyer.position.y > transform.position.y) {
			// wait before pushing the ball behind
			Invoke("PlayerFallThrough", .1f);
		} else {
			// push the ball behind right away
            PlayerFallThrough();
        }
	}

	// Pushes the ball back behind the table so it appears to fall through
	void PlayerFallThrough ()
	{
		
		plyer.position = new Vector3(plyer.transform.position.x, plyer.transform.position.y, 5);
	}
}
