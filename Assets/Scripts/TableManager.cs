using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour 
{

	void Start () 
	{
		SetTableSize();
    }
	
	public void SetTableSize () 
	{
		transform.localScale = new Vector2(Mathf.Abs(GameManager.GetTopLeft.x * 1.9f) , 22);
	}

}
