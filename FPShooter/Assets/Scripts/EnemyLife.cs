using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    public int life;
    public int maxLife;

    void Start()
    {
        maxLife = 100;
        life = maxLife;
    }

    // Update is called once per frame
    void Update() {
        Die();
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "PlayerBullet") {
            life = life - 50;
        }
    }
    void Die() {
        if (life <= 0) {
        	Destroy(this.gameObject);
        }
    }
}