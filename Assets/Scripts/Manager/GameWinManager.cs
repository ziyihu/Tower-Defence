using UnityEngine;
using System.Collections;

public class GameWinManager : MonoBehaviour {

	public TweenPosition gameWinTween;
	
	// Update is called once per frame
	void Update () {
		//if the state is game over, show the game over tween
		if (GameManager.Instance.CurStatus == GameManager.Status.WIN_GAME) {
			Time.timeScale = 0;
			gameWinTween.PlayForward();

		}
	}
}
