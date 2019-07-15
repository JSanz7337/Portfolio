using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour {

	public int maxLife = 3;
	public int actualLife;

    float pSpawnX = -0.4f;
    float pSpawnY = 0.5f;
    float pSpawnZ = -0.3f;

	public GameObject Boss;
    float bSpawnX = 28.0f;
    float bSpawnY = 0.86f;
    float bSpawnZ = -0.3f;

	void Start () {
		actualLife = maxLife;
        Boss = GameObject.FindWithTag("EnemyBoss");
	}
	
	// Update is called once per frame
	void Update () {
		if (actualLife <= 0) {
            this.transform.position = new Vector3(pSpawnX, pSpawnY, pSpawnZ);
            Boss.transform.position = new Vector3(bSpawnX, bSpawnY, bSpawnZ);
			actualLife = maxLife;
		}
	}
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Medkit") {
            actualLife = maxLife;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy") {
            actualLife = actualLife-1;
        }
        if (other.gameObject.tag == "EnemyBoss") {
            actualLife = actualLife-2;
        }
    }

}
