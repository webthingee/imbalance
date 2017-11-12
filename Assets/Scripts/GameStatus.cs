using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	[SerializeField] private int currentLives = 3;
    [SerializeField] private int currentLevel = 0;
    [SerializeField] public string levelSceneName = "Level_A_0.";

    void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

}
