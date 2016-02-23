using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public static LifeManager _instance;

	private TechNode node;

	void Awake(){
		_instance = this;
		node = new TechNode ();
	}

	private static int currentLife = 50;
	private static int maxLife = 50;

	//recovery life, only the technology is used
	private bool isActive = false;

	private float timer = 0.1f;
	private float time = 0;

	private UISprite progess;
	private UILabel percentage;
	private int currentPercentage = 0;

	//Set the life show panel
	private UILabel lifeLabel;

	// Use this for initialization
	void Start () {
		//get the life label
		//if the current percentage is 100%, add 1 life
		lifeLabel = this.transform.parent.Find("ResPanel/ResourceInfo/LifeLabel").GetComponent<UILabel> ();
		lifeLabel.text = currentLife + "/" + maxLife;

		progess = this.transform.Find ("BackGround/Progess").GetComponent<UISprite> ();
		percentage = this.transform.Find ("BackGround/Percentage").GetComponent<UILabel> ();
		progess.fillAmount = 0;
		percentage.text = "0%"+"";
	}
	public int GetLife() { return currentLife; }
	public void SetLife(int life) { currentLife = life; lifeLabel.text = currentLife + "/" + maxLife; }

		

	// Update is called once per frame
	void Update () {
		if (node.GetLifeRecovery) {
			isActive = true;
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
						if(currentLife < maxLife){
							SetLife(++currentLife);
							lifeLabel.text = currentLife + "/" + maxLife;
						} else {
							
						}
					}
					time = 0;
				}
			}
		}
		

}
