using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [Header("Game Settings")]
    private GameStatus gameStatus;
    [Header("Gear Settings")]
    [SerializeField] public float gearStartPosition;
    [SerializeField] private float gearMoveSpeed = 5f;
    [SerializeField] private float mobileMoveSpeed = 10f;
    [SerializeField] private float gearRotationSpeed = 2f;
    [SerializeField] [Range(0, 1)] private float gearSpinSensitivity;
    [Header("Field Settings")]
    [SerializeField] [Range(-1, 1)] private float verticalScrollSpeed;
    [Header("Constants")]
    [SerializeField] static Vector3 topLeft;
    [SerializeField] static Vector3 bottomLeft;

    public float GearMoveSpeed
	{
		get { return gearMoveSpeed; }
		set { gearMoveSpeed = value; }
	}

    public float MobileMoveSpeed
    {
        get { return mobileMoveSpeed; }
        set { mobileMoveSpeed = value; }
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

    public static Vector3 GetTopLeft
    {
        get { return topLeft; }
    }
    
    public static Vector3 GetBottomLeft
    {
        get { return bottomLeft; }
    }

	void Start () 
	{
        print("game started");
        topLeft = TopLeft();
        bottomLeft = BottomLeft();
        GameObject.Find("Table").GetComponent<TableManager>().SetTableSize();
    }

    void Update ()
    {
    
    }

    public void LoadNewLevel (string _level)
    {
        SceneManager.LoadScene(_level);
    }

    Vector3 TopLeft()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
        //http://answers.unity3d.com/questions/501893/calculating-2d-camera-bounds.html
    }

    Vector3 BottomLeft()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}
