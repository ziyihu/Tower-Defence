using UnityEngine;
using System.Collections;

public class DestoryDieAnim : MonoBehaviour {
	public float timer = 2;
	public float time = 0;

	// Use this for initialization
//	void Start () {
//
//		Destroy (this.gameObject, timer);
//	}
	
	void Update(){
		time += Time.deltaTime;
		if (time > timer) {
			time = 0;
			DieAniPool.instance.Push(this.gameObject);
		}
	}

}
