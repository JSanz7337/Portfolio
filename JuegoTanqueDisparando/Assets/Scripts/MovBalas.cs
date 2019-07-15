using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBalas : MonoBehaviour {
	public float speed = 0.5f;
	// Update is called once per frame
	void Update () {
		this.transform.Translate(this.transform.forward*speed, Space.World);
	}
}
