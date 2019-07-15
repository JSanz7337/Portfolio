using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int hp;
	public int maxHP = 3;

    public Image txtHealthBar;

    public AudioSource getHit;
    public AudioSource getHeal;

	public UI_Management UI_Call;

	void Start () {
		hp = maxHP;

        txtHealthBar.fillAmount = (float)hp / maxHP;
	}

    void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Enemy") {
            UI_Call.GetHit();
            hp -= 1;
			getHit.Play();
        }
        if (other.gameObject.tag == "Meat") {
            hp += 1;
			Destroy(other.gameObject);
			getHeal.Play();
        }
		if (hp > maxHP) {
			hp = maxHP;
		}
		DeathCheck();
    }

	void DeathCheck(){
		if (hp <= 0) {
			SceneManager.LoadScene("EndGame");
		}
	}
}
