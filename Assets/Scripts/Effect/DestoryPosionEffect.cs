using UnityEngine;
using System.Collections;

public class DestoryPosionEffect : MonoBehaviour {
	public float timer = 1;
	private float time = 0;
	// Use this for initialization
	void Update () {
		time += Time.deltaTime;
		if(time > timer){
			this.gameObject.GetComponent<DOTMoveAndHit>().target.SetIsPonsion(false);
			Destroy (this.gameObject);
		}
	}

}
