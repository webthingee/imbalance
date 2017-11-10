using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallCtrl : MonoBehaviour 
{
	public bool is3D;
	public float rotationSpeed = 0.1f;
	private Rigidbody2D beachBallrb;

	void Awake () {
        beachBallrb = GetComponent<Rigidbody2D>();
    }

	void Update () {
		if (is3D) {
			Add3DRotation();
		}
	}

	void Add3DRotation () {
        // positive is moving RIGHT; negitive is moving LEFT
        var localVelocity = transform.InverseTransformDirection(beachBallrb.velocity);

        // Add some x and y rotation to the beach ball
        // @TODO set the rotation to be a bit more random between 0.01 and 0.2 ?
        if (localVelocity.x > 0)
        {
            transform.Rotate(localVelocity.x, Random.Range(rotationSpeed, rotationSpeed*2), 0);
        }
        if (localVelocity.x < 0)
        {
            transform.Rotate(-localVelocity.x, -rotationSpeed, 0);
        }
	}
}
