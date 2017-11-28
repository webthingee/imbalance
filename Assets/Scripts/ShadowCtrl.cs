using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCtrl : MonoBehaviour {

	SpriteRenderer srShadow;
	Transform transShadow;
	public bool canClone = false;
	
	// Use this for initialization
	void Start () 
	{
		//GameObject shadow = new GameObject("shadow");
		GameObject shadow = Instantiate(transform.gameObject);
		shadow.GetComponent<ShadowCtrl>().enabled = false;
		transShadow = shadow.GetComponent<Transform>();
        transShadow.name = "theShadow";
        transShadow.transform.parent = transform;
        transShadow.position = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.1f);
        transShadow.localScale = new Vector3(1,1,1);

		srShadow = shadow.GetComponent<SpriteRenderer>();
		srShadow.color = Color.black;
		srShadow.sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder - 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
