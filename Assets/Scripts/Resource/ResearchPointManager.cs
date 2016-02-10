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

	private float timer = 1f;
	private float time = 0;

	private int currentPercentage = 0;
	private int currentPoint = 0;

	private bool isActive = false;
	private int speed = 0;

	//if active the Research Acceleration tech, set this to 0.1-0.9 to speed up the Research point gathering
	private static float speedUp = 1f;

	public void SetSpeedUp(float number) { if(number > 0 && number < 1) speedUp = number; }
	public float GetSpeedUp() { return speedUp; }
	
	TowerBuildManager tManager;

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
		tManager = new TowerBuildManager ();
	}
	
	// Update is called once per frame
	void Update () {
		speed = tManager.GetResearchTowerNum ();
		if (speed == 0) {
			isActive = false;
		} else {
			isActive = true;
			if(speed == 1){
				timer = 0.9f * speedUp;
			} else if(speed == 2){
				timer = 0.8f * speedUp;
			} else if(speed == 3){
				timer = 0.7f * speedUp;
			} else if(speed == 4){
				timer = 0.6f * speedUp;
			} else if(speed == 5){
				timer = 0.5f * speedUp;
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
				}
				time = 0;
			}
		}
	}
}
