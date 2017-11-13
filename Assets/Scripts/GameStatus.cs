using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	[SerializeField] private int currentLives = 3;
    [SerializeField] private int currentLevel = 0;
    [SerializeField] public string levelSceneName = "Level_A_0.";

    static GameStatus onlyGameStatus; // singleton

    public int CurrentLives
    {
        get { return currentLives; }
        set { currentLives = value; }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    void Awake ()
    {
        // set singleton
        if (onlyGameStatus != null) {
            Destroy(this.gameObject);
            return;
        }
        onlyGameStatus = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
