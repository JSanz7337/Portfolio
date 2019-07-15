using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject Cube;

	private GameObject SpawnCube;

	public bool Active;

	public float Chrono;

	void Start () {
		Active = false;
		Chrono = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Chrono += Time.deltaTime;
		if(Active==true && Chrono <= 0){
			Destroy(SpawnCube, 1.0f);
			Active = false;
		}
		if(Chrono >= 3){
			SpawnCube = (GameObject)Instantiate(Cube, this.transform.position, this.transform.rotation);
			
			Active = true;
			Chrono = -2;
		}
	}

}
