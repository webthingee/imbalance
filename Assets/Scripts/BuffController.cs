using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    Transform player;
    public Transform barrier;

	public enum Buff {one, two, barrierBuster};
	public Buff buff;



    void OnTriggerEnter2D(Collider2D other)
    {
        switch (this.buff)
		{
            case Buff.one:
                Debug.Log("One");
				AddPoints(1);
                Destroy(this.gameObject);
                break;
            case Buff.two:
                Debug.Log("Two");
                AddPoints(2);
                Destroy(this.gameObject);

                break;
            case Buff.barrierBuster:
                Debug.Log("barrierBuster"); 
                Destroy(barrier.gameObject);
                Destroy(this.gameObject);

                break;
			default:
				break;
		}
    }

    void AddPoints (int _value)
	{
		GameStatus gameStatus = GameObject.Find("Game Status").GetComponent<GameStatus>();
		if (gameStatus == null) { Debug.LogError("Game Status GameObject is not available"); return; }
		
		gameStatus.CurrentScore += _value;
	}
}
