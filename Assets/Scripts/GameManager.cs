using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    private GameStatus gameStatus;
    [SerializeField] private int currentSceneInt;
    [Header("Gear Settings")]
    [SerializeField] public float gearStartPosition;
    [SerializeField] private float gearMoveSpeed = 5f;
    [SerializeField] private float mobileMoveSpeed = 10f;
    [SerializeField] private float gearRotationSpeed = 2f;
    [SerializeField] [Range(0, 1)] private float gearSpinSensitivity;
    [Header("Field Settings")]
    [SerializeField] [Range(-20, 20)] private int verticalScrollSpeed;
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
    public int VerticalScrollSpeed
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

    void Awake ()
    {
        gameStatus = GameObject.Find("Game Status").GetComponent<GameStatus>();
        if (gameStatus == null)
        {
            Debug.LogError("Game Status GameObject is not available");
            return;
        }
    }

    void OnEnable ()
    {
        BeachBallCtrl.levelSuccessDelegate += LevelSuccess;
        BeachBallCtrl.levelFailDelegate += LevelFail;
    }

    void Start () 
	{   
        topLeft = TopLeft();
        bottomLeft = BottomLeft();
        GameObject.Find("Table").GetComponent<TableManager>().SetTableSize();

        gameStatus.ScoreChanged();
        GetCurrentScene();
    }

    void OnDisable ()
    {
        BeachBallCtrl.levelSuccessDelegate -= LevelSuccess;
        BeachBallCtrl.levelFailDelegate -= LevelFail;    
    }

    void GetCurrentScene ()
    {
        if (SceneManager.GetActiveScene().path.Contains("Levels"))
        {
            // @TODO not sure how well this works in Unity
            try
            {
                currentSceneInt = int.Parse(SceneManager.GetActiveScene().name);
            }
            catch (Exception _e)
            {
                Debug.LogError(_e.Message);
            }            
        }
    }

    void LevelFail ()
    {
        gameStatus.CurrentLevel = currentSceneInt;
        SceneManager.LoadScene(currentSceneInt);
    }

    void LevelSuccess ()
    {
        gameStatus.CurrentLevel = currentSceneInt;
        if (currentSceneInt >= gameStatus.HighestLevel) {
            gameStatus.HighestLevel = currentSceneInt; 
        }    
        SceneManager.LoadScene("LevelManager");
    }

    Vector3 TopLeft ()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
    }

    Vector3 BottomLeft ()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}
