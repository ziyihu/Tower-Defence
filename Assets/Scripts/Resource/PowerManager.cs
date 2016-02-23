using UnityEngine;
using System.Collections;

public class PowerManager : MonoBehaviour {

	public static PowerManager _instance;

	void Awake(){
		_instance = this;
	}

	private UILabel powerLabel;
	private int power;

	// Use this for initialization
	void Start () {
		powerLabel = this.transform.Find ("PowerBg/PowerNumber").GetComponent<UILabel> ();
		powerLabel.text = 0 + "";
	}
	
	// Update is called once per frame
	void Update () {
		power = TowerBuildManager._instance.GetCurrentPowerNum ();
		powerLabel.text = power + "";
	}
}
