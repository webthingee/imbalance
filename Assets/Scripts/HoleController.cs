using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

	Transform player;

	void OnTriggerEnter2D (Collider2D other)
	{
		// get and disable the collider on the line
		GameObject.Find("Line").GetComponent<EdgeCollider2D>().enabled = false;
		// set the player transform
		player = GameObject.Find("Player").GetComponent<Transform>();
		if (player.position.y > transform.position.y) {
			// wait before pushing the ball behind
			Invoke("PlayerFallThrough", .1f);
		} else {
			// push the ball behind right away
            PlayerFallThrough();
        }

        if (transform.tag == "Goal")
        {
			ExecuteGoal();
        }
        if (transform.tag == "Hole")
        {
            ExecuteHole();
        }
	}

	// Pushes the ball back behind the table so it appears to fall through
	void PlayerFallThrough ()
	{
		player.position = new Vector3(player.transform.position.x, player.transform.position.y, 5);
	}

    void ExecuteGoal()
    {
        Debug.Log("WIN!");
        player.GetComponent<BeachBallCtrl>().goal = true;
    }
    
	void ExecuteHole()
    {
        Debug.Log("FAIL!");
        player.GetComponent<BeachBallCtrl>().goal = false;
    }
}
