using UnityEngine;
using System.Collections;

public class AntennaEffects : MonoBehaviour {

	private bool move = true;
	private GameObject explosionObj = null;
	private GameObject DOTObj = null;
	public float speed = 90;

	private float timer = 2f;
	private float time = 0;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		foreach (Antenna ant in TowerBuildManager._instance.GetAntennaList()) {
			//if the antenna is providing power to the towers nearby, set the animation work
			if(ant.GetProvidePowerTowerList().Count > 0){
				ant.SetAniActive();
			} 
			//if the antenna is not working, set the animation not active
			else {
				ant.SetAniNotActive();
			}
		}

		//set the effect to show the power is providing to the towers
		if(time >= timer){
		foreach (Antenna ant in TowerBuildManager._instance.GetAntennaList()) {
			if(ant.GetProvidePowerTowerList().Count > 0 && Time.deltaTime != 0){
				foreach(Character chara in ant.GetProvidePowerTowerList()){
					//show the effect
					//start position : ant.GetPos();
					//end position : chara.GetPos();
					//effect name : powerprovide
						GameObject bulletgo = AtennaEffectPool.instance.Pop();
					CannonBullet bullet = bulletgo.GetComponent<CannonBullet>();
						bullet.move = true;
						bullet.antennaParent = this;
					bulletgo.transform.position = new Vector3(ant.GetPos().x, 0.4f, ant.GetPos().z);
					bullet.minDistance = 0.2f;
						bullet.AntennaFire(chara);
				}
			}
		}
			time = 0;
		}
	}

//	IEnumerator Shoot(Character target){
//		while (move) {
//			if(target != null){
//				Vector3 targetPos = target.GetPos();
//				this.transform.LookAt(targetPos);
//				float currentDist = Vector3.Distance(this.transform.position, target.GetPos());
//				if(currentDist < 0.5f){
//					move = false;
//					OnDOTEffect(target);
//				}
//				this.transform.Translate(Vector3.forward*Mathf.Min(speed * Time.deltaTime,currentDist));
//				yield return null;
//			}
//			else{
//				move = false;
//				GameObject.Destroy(gameObject);
//				move = true;
//			}
//		}
//	}
//
//	public void OnDOTEffect(Character chara){
//		DOTObj = (GameObject)GameObject.Instantiate(Resources.Load("DOT"));
//		DOTObj.transform.position = chara.GetPos ();
//		DOTObj.GetComponent<DOTMoveAndHit> ().SetTarget (chara);
//	}

}
