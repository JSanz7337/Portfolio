using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTanque : MonoBehaviour {

	public int vel = 3;
	public int rotationF = 35;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W)){
            this.transform.Translate(0,0, vel * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -vel * Time.deltaTime);
        }

		if (Input.GetKey(KeyCode.A)){
            if (Input.GetKey(KeyCode.S)) {
                this.transform.Rotate(0, rotationF * Time.deltaTime, 0);
			}else {
                this.transform.Rotate(0, -rotationF * Time.deltaTime, 0);
            }
		}
        if (Input.GetKey(KeyCode.D)) {
            if (Input.GetKey(KeyCode.S)) {
                this.transform.Rotate(0, -rotationF * Time.deltaTime, 0);
            }else {
                this.transform.Rotate(0, rotationF * Time.deltaTime, 0);
            }
        }
        
	}
}
