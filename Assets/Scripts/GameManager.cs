using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /* @TODO: change these to private */
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float yLimiter;
    [Range(0, 1)] public float spinSensitivity;

	// Use this for initialization
	void Start () {
		print("game started");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
