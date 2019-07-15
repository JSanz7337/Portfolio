using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if (this.gameObject.tag == "Bullet") {
			if (other.gameObject.tag == "Player") {
				Destroy(this.gameObject);
			}
		}  	
	}
}
