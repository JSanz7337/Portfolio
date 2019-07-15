using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawn : MonoBehaviour {

	public GameObject enemy;

	public float count;
	public float stop;

	public int min = 1;
	public int max = 6;

	public Vector3 dirSpawn = Vector3.right;

	void Start (){
        Calc();
	}

	void Update () {
		count = count+Time.deltaTime;

		if (count > stop) {

			GameObject enemySpawn = (GameObject)Instantiate(enemy, this.transform.position, this.transform.rotation);
			enemySpawn.GetComponent<IAmove>().dir = dirSpawn;

			count = 0;
			Calc();	
		}
	}

	void Calc(){
        stop = Random.Range(min, max);
	}
}
