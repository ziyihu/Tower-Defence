using UnityEngine;
using System.Collections;

public class DestoryEffect : MonoBehaviour {

	public float timer = 1;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, timer);
	}
	

}
