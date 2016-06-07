using UnityEngine;
using System.Collections;

public class ResearchPointManager : MonoBehaviour {

	public static ResearchPointManager _instance;

	void Awake(){
		_instance = this;
	}

	private UILabel currentPointLabel;
	private UISprite progess;
	private UILabel percentage;

	public UILabel techTreeCurrentPointLabel;
	public UILabel techTree2CurrentPointLabel;
	public UILabel techTree3CurrentPointLabel;

	private float timer = 1f;
	private float time = 0;

	private int currentPercentage = 0;
	private int currentPoint = 31;

	public void SetCurrentPoint(int point){
		currentPoint = point;
	}

	private bool isActive = false;
	private int speed = 0;

	//if active the Research Acceleration tech, set this to 0.1-0.9 to speed up the Research point gathering
	private static float speedUp = 1f;

	public void SetSpeedUp(float number) { if(number > 0 && number < 1) speedUp = number; }
	public float GetSpeedUp() { return speedUp; }

	public int GetResearchPoint() { return currentPoint; }
	public void UseResearchPoint() { currentPoint = currentPoint - 1; }


	public void SetActive(){
		isActive = true;
	}

	public void SetSpeed(int speed){
		this.speed = speed;
	}

	// Use this for initialization
	void Start () {
		currentPointLabel = this.transform.Find ("CurrentPointNum").GetComponent<UILabel> ();
		progess = this.transform.Find ("BackGround/Progess").GetComponent<UISprite> ();
		percentage = this.transform.Find ("BackGround/Percentage").GetComponent<UILabel> ();
		progess.fillAmount = 0;
		percentage.text = "0%"+"";
		currentPointLabel.text = 0 + "";
	}
	
	// Update is called once per frame
	void Update () {
		currentPointLabel.text = currentPoint+"";
		techTreeCurrentPointLabel.text = currentPoint + "";
		techTree2CurrentPointLabel.text = currentPoint + "";
		techTree3CurrentPointLabel.text = currentPoint + "";
		speed = TowerBuildManager._instance.GetResearchTowerNum ();
		if (speed == 0) {
			isActive = true;
			timer = 0.5f;
		} else {
			isActive = true;
			if(speed == 1){
				timer = 0.47f * speedUp;
			} else if(speed == 2){
				timer = 0.44f * speedUp;
			} else if(speed == 3){
				timer = 0.41f * speedUp;
			} else if(speed == 4){
				timer = 0.38f * speedUp;
			} else if(speed == 5){
				timer = 0.35f * speedUp;
			}
		}
		time += Time.deltaTime;
		if (isActive) {
			if(timer <= time){
				if(currentPercentage < 100){
					currentPercentage++;
					//set the percentage
					progess.fillAmount = currentPercentage / 100f;
					//set the label
					percentage.text = currentPercentage+"%"+"";
				} else if(currentPercentage == 100){
					currentPercentage = 0;
					progess.fillAmount = 0;
					percentage.text = "0%"+"";
					currentPoint++;
					currentPointLabel.text = currentPoint+"";
					techTreeCurrentPointLabel.text = currentPoint + "";
					techTree2CurrentPointLabel.text = currentPoint+"";
					techTree3CurrentPointLabel.text = currentPoint + "";
				}
				time = 0;
			}
		}
	}
}
