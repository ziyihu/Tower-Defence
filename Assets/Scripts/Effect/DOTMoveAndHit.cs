using UnityEngine;
using System.Collections;

public class DOTMoveAndHit : MonoBehaviour {

	private float timer = 0.5f;
	private int attackNum = 3;
	private float time = 0;
	private float time2 = 0;
	private float removeTimer = 2f;

	public Character target;

	public void SetTarget(Character enemy){
		target = enemy;
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
			time2 += Time.deltaTime;
			if(timer < time){
				target.OnBeHit(attackNum);
				time = 0;
			}
			if(time2 > removeTimer){
				target.SetIsPonsion(false);
				time2 = 0;
			}
		}
	}
}
