using UnityEngine;
using System.Collections;

public class DOTMoveAndHit : MonoBehaviour {

	private float timer = 0.33f;
	private int attackNum = 30;
	private float time = 0;

	public Character target;

	public void SetTarget(Character enemy){
		target = enemy;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			this.transform.position = target.GetPos();
		} else {
			Destroy(this.gameObject);
		}
		if (target.Life <= 0) {
			Destroy(this.gameObject);
		}
		//if the Life is more than 0, attack the current enemy
		if (target.Life > 0) {
			time += Time.deltaTime;
			if(timer < time){
				target.OnBeHit(attackNum);
				time = 0;
			}
		}
	}
}
