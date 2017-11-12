﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour 
{

	void Start () {
        transform.localScale = new Vector2(Mathf.Abs(GameManager.GetTopLeft.x * 1.9f), 22);
    }
	
	public void SetTableSize () 
	{
		transform.localScale = new Vector2(Mathf.Abs(GameManager.GetTopLeft.x * 1.9f) , 22);
	}

}