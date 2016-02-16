using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	public static LifeManager _instance;

	void Awake(){
		_instance = this;
	}

	private static int currentLife = 9;
	private static int maxLife = 9;

	private UILabel lifeLabel;

	// Use this for initialization
	void Start () {
		lifeLabel = this.transform.parent.Find("ResPanel/ResourceInfo/LifeLabel").GetComponent<UILabel> ();
		lifeLabel.text = currentLife + "/" + maxLife;
	}
	public int GetLife() { return currentLife; }
	public void SetLife(int life) { currentLife = life; lifeLabel.text = currentLife + "/" + maxLife; }

		

	// Update is called once per frame
	void Update () {
	
	}
}
