using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject fxKill;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject, 1.0f);

            GameObject particleSpawn = (GameObject)Instantiate(fxKill, this.transform.position, this.transform.rotation);
			Destroy(particleSpawn, 3.0f);
		}
        if (other.gameObject.tag != "Bullet"){
			Destroy(this.gameObject);
		}
	}
}