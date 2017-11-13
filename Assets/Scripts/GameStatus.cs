using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

    [SerializeField] private int currentScore;
    [SerializeField] private int currentLives;
    [SerializeField] private int currentLevel;
    [SerializeField] public string levelSceneName = "Level_A_0.";

    static GameStatus onlyGameStatus; // singleton

    public delegate void ChangeScore(int value);
    public static ChangeScore changeScoreDelegate;

    public int CurrentScore
    {
        get { return currentScore; }
        set 
        { 
            currentScore = value; 
            ScoreChanged();
        }
    }
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

    public void ScoreChanged ()
    {
        changeScoreDelegate(currentScore);
    }
}
