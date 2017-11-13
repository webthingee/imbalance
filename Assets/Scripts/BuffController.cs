using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    Transform player;

	public enum Buff {one, two, three};
	public Buff buff;



    void OnTriggerEnter2D(Collider2D other)
    {
        switch (this.buff)
		{
            case Buff.one:
                Debug.Log("One");
				AddPoints(111);
                break;
            case Buff.two:
                Debug.Log("Two");
                break;
            case Buff.three:
                Debug.Log("Three");
                break;
			default:
				break;
		}
    }

    void AddPoints (int _value)
	{
		GameStatus gameStatus = GameObject.Find("Game Status").GetComponent<GameStatus>();
		if (gameStatus == null) {
			Debug.LogError("Game Status GameObject is not available");
			return;
		}
		
		gameStatus.CurrentScore += _value;
	}
}
