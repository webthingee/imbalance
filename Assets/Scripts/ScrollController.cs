using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour {

	GameManager gm;

	void Awake ()
	{
		gm = FindObjectOfType<GameManager>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector2.up * (gm.VerticalScrollSpeed * .001f));
	}
}
