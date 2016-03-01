using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public TweenPosition gameOverTween;
	public UILabel deadWave;

	// Update is called once per frame
	void Update () {
		//if the state is game over, show the game over tween
		if (GameManager.Instance.CurStatus == GameManager.Status.END_GAME) {
			Time.timeScale = 0;
			gameOverTween.PlayForward();

				deadWave.text = WaveManager._instance.GetCurrentWave() + "/" + WaveManager._instance.GetMaxWave();

		}
	}
}
