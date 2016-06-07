using UnityEngine;
using System.Collections;

public class PowerBlink : MonoBehaviour {

	public UISprite diamondIcon;
	private float time = 0;
	private float timer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (TowerBuildManager._instance.GetCurrentPowerNum() == 0) {
			time+=Time.deltaTime;
			if(time > timer && time < timer + 0.5f){
				diamondIcon.gameObject.SetActive(false);
			} else if(time < timer){
				diamondIcon.gameObject.SetActive(true);
			} else {
				diamondIcon.gameObject.SetActive(true);
				time = 0;
			}
		} else {
				diamondIcon.gameObject.SetActive(true);
		}
	}
}
