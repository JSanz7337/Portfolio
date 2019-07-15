using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitRotation : MonoBehaviour {

	public Rigidbody rbItem;

	void Start () {
        	rbItem = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       		rbItem.angularVelocity = new Vector3(0, 2, 0);
	}
}
