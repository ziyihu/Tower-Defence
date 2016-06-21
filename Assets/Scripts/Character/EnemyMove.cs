using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	private GameObject effect11 = null;

	private TechNode node;

	//extra slow time
	private bool isExtraSlow = false;
	private float timer = 2.0f;
	private float time = 0;

	void Start(){
		node = new TechNode ();
	}


	// Update is called once per frame
	void Update () {
		for (int i = 0; i < EnemySpawnManager._instance.enemyList.Count; i++) {
			Enemy enemy = (Enemy)EnemySpawnManager._instance.enemyList [i];
			QuadTextureAni ani = enemy.GetTransform().GetComponentInChildren<QuadTextureAni> ();
			//enemy.SetPos (new Vector3 (enemy.GetPos ().x + 0.01f * Time.timeScale, enemy.GetPos ().y, enemy.GetPos ().z));
			if(enemy.GetPos().x < 15.45f){
			//first path, walk down
				enemy.SetPos (new Vector3 (enemy.GetPos ().x + enemy.Speed * Time.timeScale, enemy.GetPos ().y, enemy.GetPos ().z));
			}
			else if(enemy.GetPos().x <= 19.8f && enemy.GetPos().x >=15.45f && enemy.GetPos().z >= 18.6f && enemy.GetPos().z <= 25.6f){
			//second path, walk left
				if (ani != null) {
					ani.namePrefix = "walkright";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					if(enemy.characterType == CharacterData.CharacterModel.BOWMAN || enemy.characterType == CharacterData.CharacterModel.VIKING){
						ani.mirror = true;
					} else {
						ani.mirror = false;
					}
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x , enemy.GetPos ().y, enemy.GetPos ().z - enemy.Speed * Time.timeScale));
			}
			else if(enemy.GetPos().z > 18.2f && enemy.GetPos().z < 18.6f && enemy.GetPos().x >= 15.45f && enemy.GetPos().x <= 19.8f){
			//third path, walk down
				if (ani != null) {
					ani.namePrefix = "walkdown";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					ani.mirror = false;
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x + enemy.Speed * Time.timeScale, enemy.GetPos ().y, enemy.GetPos ().z));
			}
			else if(enemy.GetPos().x < 19.9f && enemy.GetPos().x > 19.8f && enemy.GetPos().z <= 23.5f){
			//forth path, walk right
				if (ani != null) {
					ani.namePrefix = "walkright";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					if(enemy.characterType == CharacterData.CharacterModel.BOWMAN || enemy.characterType == CharacterData.CharacterModel.VIKING){
						ani.mirror = false;
					} else {
						ani.mirror = true;
					}
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x , enemy.GetPos ().y, enemy.GetPos ().z + enemy.Speed * Time.timeScale));
			}
			else if(enemy.GetPos().z < 23.6f && enemy.GetPos().z >= 23.5f && enemy.GetPos().x > 19.8f && enemy.GetPos().x <= 22.3f){
			//fifth path, walk down
				if (ani != null) {
					ani.namePrefix = "walkdown";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					ani.mirror = false;
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x + enemy.Speed * Time.timeScale, enemy.GetPos ().y, enemy.GetPos ().z));
			}
			else if(enemy.GetPos().x < 22.6f && enemy.GetPos().x > 22.3f && enemy.GetPos().z <= 23.6f && enemy.GetPos().z >= 19.5f){
			//sixth path,walk left
				if (ani != null) {
					ani.namePrefix = "walkright";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					if(enemy.characterType == CharacterData.CharacterModel.BOWMAN || enemy.characterType == CharacterData.CharacterModel.VIKING){
						ani.mirror = true;
					} else {
						ani.mirror = false;
					}
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x , enemy.GetPos ().y, enemy.GetPos ().z - enemy.Speed * Time.timeScale));
			}
			else if(enemy.GetPos().x >= 22.3f && enemy.GetPos().z < 19.5f){
				//seventh path,walk down
				if (ani != null) {
					ani.namePrefix = "walkdown";
					ani.mFPS = 20;
					ani.RebuildSpriteList();
					ani.mirror = false;
				}
				enemy.SetPos (new Vector3 (enemy.GetPos ().x + enemy.Speed * Time.timeScale, enemy.GetPos ().y, enemy.GetPos ().z));
			}
			if(enemy.GetPos().x > 23.2f){
				//show the escape effect
				//TODO
				AudioSource.PlayClipAtPoint(AudioManager._instance.escapeMusic,enemy.GetPos());
				effect11 = (GameObject)GameObject.Instantiate(Resources.Load("effect11"));
				effect11.transform.position = enemy.GetPos ();
				//current life decrease 1
				//if life is less than 0, game over
				if(LifeManager._instance.GetLife() > 1){
					LifeManager._instance.SetLife(LifeManager._instance.GetLife()-1);
				} else if(LifeManager._instance.GetLife() == 1){
					LifeManager._instance.SetLife(LifeManager._instance.GetLife()-1);
					GameManager.Instance.CurStatus = GameManager.Status.END_GAME;
				}
				EnemySpawnManager._instance.enemyList.Remove(enemy);
				enemy.Destroy();
				//last enemy will not affect the speed
				//enemy reach base, if the extra slow1 is active
				if(node.GetExtraSlow){
					if(EnemySpawnManager._instance.enemyList.Count != 0){
						//set the variable 
						TowerBuildManager._instance.SetExtraSlowNum(0.8f);
						isExtraSlow = true;
						time = 0;
					} else {
						TowerBuildManager._instance.SetExtraSlowNum(1.0f);
						isExtraSlow = false;
						time = 0;
					}
				}
			}
		}
		if (isExtraSlow) {
			time += Time.deltaTime;
			if(time >= timer){
				TowerBuildManager._instance.SetExtraSlowNum(1.0f);
				isExtraSlow = false;
				time = 0;
			}
		}

	}
}
