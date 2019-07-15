using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparos : MonoBehaviour {

	public GameObject Shoot;
	public GameObject Spawn;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(Shoot, Spawn.transform.position, this.transform.rotation);	
		}
	}
}
