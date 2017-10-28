using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private float gearMoveSpeed = 5f;
    [SerializeField] private float gearRotationSpeed = 2f;
    [SerializeField] [Range(0, 1)] private float gearSpinSensitivity;

	public float GearMoveSpeed
	{
		get { return gearMoveSpeed; }
	}

    public float GearRotationSpeed
    {
        get { return gearRotationSpeed; }
    }

    public float GearSpinSensitivity
    {
        get { return gearSpinSensitivity; }
    }

	void Start () 
	{
		print("game started");
	}
}
