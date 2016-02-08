using UnityEngine;
using System.Collections;

public class PowerManager : MonoBehaviour {

	public static PowerManager _instance;

	void Awake(){
		_instance = this;
	}

	private UILabel powerLabel;
	private int power;
	TowerBuildManager tManager;

	// Use this for initialization
	void Start () {
		powerLabel = this.transform.Find ("PowerBg/PowerNumber").GetComponent<UILabel> ();
		powerLabel.text = 0 + "";
		tManager = new TowerBuildManager ();
	}
	
	// Update is called once per frame
	void Update () {
		power = tManager.GetCurrentPowerNum ();
		powerLabel.text = power + "";
	}
}
