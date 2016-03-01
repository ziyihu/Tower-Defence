using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public static WaveManager _instance;

	void Awake(){
		_instance = this;
	}

	private UILabel waveLabel;

	private static int currentWave = 1;
	private static int maxWave = 20;

	public int GetMaxWave(){
		return maxWave;
	}

	public void addCurrentWave(){
		currentWave += 1;
	}

	public void SetCurrentWave(int wave){
		if (wave < maxWave) {
			currentWave = wave;
		} else {
			currentWave = maxWave;
		}
	}
	public int GetCurrentWave(){
		return currentWave;
	}

	// Use this for initialization
	void Start () {
		waveLabel = this.transform.Find ("Wave/Label").GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		waveLabel.text = currentWave + "/" + maxWave;
	}
}
