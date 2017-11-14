﻿using System.Collections;
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
        Debug.Log(gameStatus.levelSceneName);
    }

    void OnDisable ()
    {
        BeachBallCtrl.levelSuccessDelegate -= LevelSuccess;
        BeachBallCtrl.levelFailDelegate -= LevelFail;    
    }

    public void LoadNewLevel (string _level)
    {
        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }

        Debug.Log(_level);

        if (scenesInBuild.Contains(_level)) 
        {
            SceneManager.LoadScene(_level);
        } else {
            SceneManager.LoadScene("Playground");
        }
    }

    void LevelFail ()
    {   
        LoadNewLevel(gameStatus.levelSceneName + gameStatus.CurrentLevel.ToString());
    }

    void LevelSuccess ()
    {
        gameStatus.CurrentLevel += 1;
        LoadNewLevel(gameStatus.levelSceneName + gameStatus.CurrentLevel.ToString());
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
