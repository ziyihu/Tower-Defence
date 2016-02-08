using UnityEngine;
using System.Collections;

public class DiamondCollectionEffect : MonoBehaviour {

	public int ID { get; set; }
	public float DelayTime{ get; set; }
	
	public float speed = 90;
	public float maxTime = 2;
	public float Timer = 0;

	private float distanceToTarget;
	private bool move = true;
	private Character curTarget;
	private float Distance;
	private float explosionRange = 1.0f;
	
	private GameObject explosionObj = null;
	
	public void Fire(Character target){
		curTarget = target;
		Transform house = transform.GetChild (0);
		house.gameObject.GetComponent<Renderer>().sortingOrder = 4;
		distanceToTarget = Vector3.Distance (this.transform.position, target.GetPos());
		StartCoroutine (Shoot (target));
	}
	
	IEnumerator Shoot(Character target){
		while (move) {
			if(target != null){
				Vector3 targetPos = target.GetPos();
				this.transform.LookAt(targetPos);
				float currentDist = Vector3.Distance(this.transform.position, target.GetPos());
				if(currentDist < 0.5f){
					move = false;
					OnHited();
				}
				this.transform.Translate(Vector3.forward*Mathf.Min(speed * Time.deltaTime,currentDist));
				yield return null;
			}
			else{
				move = false;
				GameObject.Destroy(gameObject);
			}
		}
	}
	
	public void OnExplosionEffect(){
		//create a new game object to show the explosion effect
		explosionObj = (GameObject)GameObject.Instantiate (Resources.Load ("explosion"));
		explosionObj.transform.position = curTarget.GetPos();
	}
	
	public void OnHited(){
		OnExplosionEffect ();
		GameObject.Destroy (gameObject);
	}
	
	public void Update(){
		Timer += Time.deltaTime;
		if (Timer >= maxTime) {
			GameObject.Destroy(gameObject);
			Timer = 0;
		}
	}
}
