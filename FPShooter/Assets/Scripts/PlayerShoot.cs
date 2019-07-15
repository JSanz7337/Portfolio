using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public GameObject Bullet;
    public GameObject BulletZone;
    public int BulletForce;

    public int magazine;
    public float reloadTime;

    public Text txtMagazine;
    public Text txtReload;

    void Start(){
        BulletForce = 15;
        magazine = 20;
        reloadTime = 3;
        txtMagazine.text = "Balas: "+magazine+"/20";
        txtReload.text = " ";
    }
	
	void Update () {
		Shooting();
	}

    void Shooting(){
            if (magazine <= 0) {
                Reload();
            }else {
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    GameObject BulletSpawn = (GameObject)Instantiate(Bullet, BulletZone.transform.position, BulletZone.transform.rotation);
                    Rigidbody rigidBullet1 = BulletSpawn.GetComponent<Rigidbody>();
                    rigidBullet1.velocity = BulletSpawn.transform.forward * BulletForce;
                    magazine = magazine-1;
                    txtMagazine.text = "Balas: " + magazine + "/20";
                    Destroy(BulletSpawn, 3.0f); 
            }
        }
    }
    void Reload(){
        txtReload.text = "Recargando!";
        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0.0f) {
            reloadTime = 3;
            magazine = 20;
            txtMagazine.text = "Balas: " + magazine + "/20";
            txtReload.text = " ";
        }
    }
}
