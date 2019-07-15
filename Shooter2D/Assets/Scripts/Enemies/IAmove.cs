using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmove : MonoBehaviour {

	public float vel = 2;

	public Vector3 dir = Vector3.right;

    public GameObject fxDie;

    public AudioSource dieSound;

	void Update () {
		this.transform.Translate(dir*vel*Time.deltaTime, Space.World);
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet") {
            dieSound.Play();
        }
    }
}
