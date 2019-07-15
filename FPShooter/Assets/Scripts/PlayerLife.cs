using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public int life;
	public int maxLife;

    float pSpawnX = -28.38f;
    float pSpawnY = 1.03f;
    float pSpawnZ = 6.92f;

    public Text txtLife;
    public Image txtHealthBar;
    float txtShowLife;

	void Start () {
		maxLife = 100;
        life = maxLife;
        txtLife.text = life + "/" + maxLife;
        txtShowLife = (float) life/maxLife;
        txtHealthBar.fillAmount = txtShowLife;
	}
	
	// Update is called once per frame
	void Update () {
		Die();
	}
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "MedKit") {
            if (life+25>maxLife) {
				life = maxLife;
                txtLife.text = life+"/"+maxLife;
			}else {
                life = life + 25;
                txtLife.text = life + "/" + maxLife;	
			}
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy") {
            life = life - 10;
            txtLife.text = life + "/" + maxLife;
        }
        if (other.gameObject.tag == "Bullet") {
            life = life - 15;
            txtLife.text = life + "/" + maxLife;
        }
        txtShowLife = (float)life / maxLife;
        txtHealthBar.fillAmount = txtShowLife;
    }
	void Die(){
        if (life <= 0) {
            this.transform.position = new Vector3(pSpawnX, pSpawnY, pSpawnZ);
            life = maxLife;
            txtLife.text = life + "/" + maxLife;
            txtShowLife = (float)life / maxLife;
            txtHealthBar.fillAmount = txtShowLife;
        }
	}
}
