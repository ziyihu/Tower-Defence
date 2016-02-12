using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	private static int currentLife = 30;

	public int GetLife() { return currentLife; }
	public void SetLife(int life) { currentLife = life; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
