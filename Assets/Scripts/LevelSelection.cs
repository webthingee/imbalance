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

	void OnEnable ()
	{
		EnableAvailableLevelButtons();
	}

	void Start ()
	{
		gameLevelText.text = UpdateText();
	}

	string UpdateText ()
	{
		string _text = "";
		if (gameStatus.CurrentLevel > 0) {
			_text += "You have just completed level " + gameStatus.CurrentLevel.ToString();
			_text += "\n";
			_text += "Your highest level completed is " + gameStatus.HighestLevel.ToString();
		}

		return _text;
	}

	public void LoadLevel (string _level)
	{
		SceneManager.LoadScene(_level);
	}

    void EnableAvailableLevelButtons()
    {
        // get all the buttons
		Button[] _lvlBtns = GetComponentsInChildren<Button>();
        
		foreach (Button _btn in _lvlBtns)
        {
            // disable all
			_btn.interactable = false;
            
			// check the level text against the hightst level completed
			if (int.Parse(_btn.GetComponentInChildren<Text>().text) <= gameStatus.HighestLevel + 1)
            {
                _btn.interactable = true;
            }
        }
    }

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
