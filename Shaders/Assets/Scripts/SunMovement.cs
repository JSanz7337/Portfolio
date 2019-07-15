using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour {

	public GameObject Sun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Sun.transform.Translate(Vector3.up * Time.deltaTime);
	}
}
