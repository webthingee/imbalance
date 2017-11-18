using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour 
{
    private GameStatus gameStatus;
	public Text gameLevelText;
    [SerializeField] public List<string> scenesInLevel = new List<string>();

    void Awake () 
	{
        gameStatus = GameObject.Find("Game Status").GetComponent<GameStatus>();
        if (gameStatus == null)
        {
            Debug.LogError("Game Status GameObject is not available");
            return;
        }
	}

	// get all the buttons
	// disable all
	// enable once previous is passed


    // public void LoadLevel (int _level)
    // {
    //     Debug.Log(gameStatus.gameLevels.Count);
    //     Debug.Log(_level);

    //     if (_level < scenesInLevel.Count)
    //     {
    //         SceneManager.LoadScene(scenesInLevel[_level]);
    //     }
    //     else
    //     {
    //         SceneManager.LoadScene("Playground");
    //     }
    // }

	void Start ()
	{
        
		gameLevelText.text = UpdateText();
		
		
		// for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        // {
        //     string scenePath = SceneUtility.GetScenePathByBuildIndex(i);

        //     if (scenePath.Contains("Levels"))
        //     {
        //         int lastSlash = scenePath.LastIndexOf("/");
        //         string levelName = scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1);
        //         scenesInLevel.Add(levelName);
        //     }
        // }
	}

	string UpdateText ()
	{
		string _text = "";
		_text += "You have just completed level " + gameStatus.CurrentLevel.ToString();
		_text += "\n Your highest level completed is " + gameStatus.HighestLevel.ToString();

		return _text;
	}

	public void LoadLevel (string _level)
	{
		SceneManager.LoadScene(_level);
	}
}
