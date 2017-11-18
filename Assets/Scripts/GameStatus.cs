using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    [SerializeField] private int currentScore = 0;
    [SerializeField] private int currentLives = 3;
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int highestLevel = 0;
    //[SerializeField] public List<string> gameLevels = new List<string>();


    static GameStatus onlyGameStatus; // singleton

    public delegate void ChangeScore(int value);
    public static event ChangeScore changeScoreDelegate;

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
    public int HighestLevel
    {
        get { return highestLevel; }
        set { highestLevel = value; }
    }

    void Awake ()
    {
        if (onlyGameStatus != null) { // set singleton
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
