using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

	public GameObject goPlayer;

	Vector3 playerDistance;
	public float Distance;
	float Angle;
	public float AngularVision;

    public GameObject Bullet;
    public GameObject BulletZone;
    public int BulletForce;

	float bulletTime;

    void Start() {
        Angle = 60;
		Distance = 15;
		bulletTime = 1;
		BulletForce = 10;
    }
	// Update is called once per frame
	void Update () {
		PlayerDetection();
	}

	void PlayerDetection(){
        playerDistance = goPlayer.transform.position - this.transform.position;
        if (playerDistance.magnitude < Distance) {
			RaycastHit resultadoRay;
			if (Physics.Raycast(this.transform.position, playerDistance, out resultadoRay, 40)) {
				if (resultadoRay.transform.tag == "Player"){
					Angle = Vector3.Angle(this.transform.forward,playerDistance);
					if (Angle < AngularVision) {
                        transform.LookAt(goPlayer.transform);
                        bulletTime -= Time.deltaTime;
						if (bulletTime <= 0.0f){
                            GameObject BulletSpawn = (GameObject)Instantiate(Bullet, BulletZone.transform.position, BulletZone.transform.rotation);
                            Rigidbody rigidBullet1 = BulletSpawn.GetComponent<Rigidbody>();
                            rigidBullet1.velocity = BulletSpawn.transform.forward * BulletForce;
                            Destroy(BulletSpawn, 3.0f);
							bulletTime = 1;	
						}
                    }
				}
			}
        }
	}
}
