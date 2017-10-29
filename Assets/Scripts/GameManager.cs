using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Gear Settings")]
    [SerializeField] private float gearMoveSpeed = 5f;
    [SerializeField] private float gearRotationSpeed = 2f;
    [SerializeField] [Range(0, 1)] private float gearSpinSensitivity;
    [Header("Field Settings")]
    [SerializeField] [Range(-1, 1)] private float verticalScrollSpeed;

    public float GearMoveSpeed
	{
		get { return gearMoveSpeed; }
		set { gearMoveSpeed = value; }
	}

    public float GearRotationSpeed
    {
        get { return gearRotationSpeed; }
        set { gearRotationSpeed = value; }
    }

    public float GearSpinSensitivity
    {
        get { return gearSpinSensitivity; }
        set { gearSpinSensitivity = value; }
    }

    public float VerticalScrollSpeed
    {
        get { return verticalScrollSpeed; }
        set { verticalScrollSpeed = value; }
    }

	void Start () 
	{
		print("game started");
	}
}
