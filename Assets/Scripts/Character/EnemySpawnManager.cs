using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour {

	public static EnemySpawnManager _instance;

	public EnemySpawn[] bowmanBornArray;
	public EnemySpawn[] vikingBornArray;
	public EnemySpawn[] gaintBornArray;

	public bool isStart = false;

	public List<Character> enemyList = new List<Character>();
	GameObject startPoint;
	EnemySpawn enemySpawn;

	void Awake(){
		_instance = this;
		GameObject startPoint = GameObject.Find ("StartPoint");
		enemySpawn = new EnemySpawn ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Born ());
	}

	IEnumerator Born(){

		//the first wave enemy
		for(int i = 0 ; i < 10 ; i++){
			enemyList.Add(enemySpawn.EnemyBorn("bowman"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		
		//second wave enemy
		foreach (EnemySpawn s in vikingBornArray) {
			enemyList.Add(s.Born());
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count>0) {
			yield return new WaitForSeconds(0.2f);
		}


		//enemy 2 - 9
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy2"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy3"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy4"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy5"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy6"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy7"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy8"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy9"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}


		//enemy 10 - 19

		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy11"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy12"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy14"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy18"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy19"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		
	
		//enemy 20 - 29
		
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy20"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy23"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy25"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy26"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy29"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}

		//enemy 30 - 39
	
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy31"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy32"));
			yield return new WaitForSeconds(1f);
		}

		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy34"));
			yield return new WaitForSeconds(1f);
		}
	
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy36"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy37"));
			yield return new WaitForSeconds(1f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy38"));
			yield return new WaitForSeconds(1f);
		}


		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}

		//enemy 40 - 46
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy40"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy41"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy42"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy43"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy44"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("enemy46"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}


		//boss1 and boss2
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("boss1"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}
		for (int i = 0; i < 10; i++) {
			enemyList.Add(enemySpawn.EnemyBorn("boss2"));
			yield return new WaitForSeconds(1f);
		}
		while (enemyList.Count > 0) {
			yield return new WaitForSeconds(0.2f);
		}

	}

}
