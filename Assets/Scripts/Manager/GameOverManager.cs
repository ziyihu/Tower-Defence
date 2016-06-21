using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public TweenPosition gameOverTween;
	public UILabel deadWave;

	private bool isSaved = false;
	private float time = 0f;

	void Start(){
		time = 0;
		isSaved = false;
	}

	// Update is called once per frame
	void Update () {
		//if the state is game over, show the game over tween
		if (GameManager.Instance.CurStatus == GameManager.Status.END_GAME) {
			time += Time.deltaTime;

			if(time < 1f) {
				Application.CaptureScreenshot("TechnologyTree"+InformationSave.instance.TechTree+".jpg");
			} else {
			Time.timeScale = 0;

			//end time
			InformationSave.instance.LastTime = Time.timeSinceLevelLoad;
			//left life
			InformationSave.instance.LeftLife = LifeManager._instance.GetLife();
			//attack building number
			InformationSave.instance.AttackingBuildingsNum = TowerBuildManager._instance.AttackBuildingNum();
			//all building number
			InformationSave.instance.BuildingsNum = TowerBuildManager._instance.AllBuildingNum();
			//power generated 
			InformationSave.instance.PowerGenerated = TowerBuildManager._instance.PowerGenerated();


			if(isSaved == false){
				InformationSave.instance.SaveInforToADoc();
				isSaved = true;
			}

			gameOverTween.PlayForward();

				deadWave.text = WaveManager._instance.GetCurrentWave() + "/" + WaveManager._instance.GetMaxWave();
			}
		}
	}
}
