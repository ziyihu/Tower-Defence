using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiamondManager : MonoBehaviour {

	public static DiamondManager _instance;

	void Awake(){
		_instance = this;
	}

	private UILabel diamondLabel;
	
	private float timer = 1f;
	private float time = 0;
	private int currentDiamond = 20000;
	
	private bool isActive = false;
	private int speed = 0;
	
	TowerBuildManager tManager;

	// Use this for initialization
	void Start () {
		diamondLabel = this.transform.Find ("ResourceInfo/DiamondLabel").GetComponent<UILabel> ();
		diamondLabel.text = 0 + "";
		tManager = new TowerBuildManager ();
	}

	public int GetCurrentDiamond(){
		return currentDiamond;
	}

	public void AddDiamond(int number){
		currentDiamond += number;
	}

	public void UseDiamond(int number){
		currentDiamond -= number;
	}

	// Update is called once per frame
	void Update () {
		diamondLabel.text = currentDiamond + "";
		speed = tManager.GetDiamondCollectionSpeedNum ();
		time += Time.deltaTime;
		diamondLabel.text = currentDiamond + "";
		if (speed > 0) {
			if(timer <= time){
				StartCoroutine(Add(speed));
				time = 0;
			}
		}
	}

	IEnumerator Add(int speed){
		for(int i = 1; i <= speed; i++){
			currentDiamond += 1;
			diamondLabel.text = currentDiamond + "";
			yield return new WaitForSeconds(0.08f);
		}
	}
}

