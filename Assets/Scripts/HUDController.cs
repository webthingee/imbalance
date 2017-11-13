using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public Text scoreText;
	public Text livesText;

	void OnEnable ()
	{
		GameStatus.changeScoreDelegate += UpdateScore;
	}

    void OnDisable ()
    {
        GameStatus.changeScoreDelegate -= UpdateScore;
    }

	void UpdateScore (int _value) // changeScoreDelegate
	{
		scoreText.text = _value.ToString();
	}
}
