using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour {

	bool Red = false;
	bool Blue = false;
	bool Green = false;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "RedKey") {
			Red = true;
			Destroy(other.gameObject);
		}
        if (other.gameObject.tag == "BlueKey") {
            Blue = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "GreenKey") {
            Green = true;
            Destroy(other.gameObject);
        }
		if (other.gameObject.tag == "RedDoor" && Red == true) {
            Destroy(other.gameObject);
		}
        if (other.gameObject.tag == "BlueDoor" && Blue == true) {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "GreenDoor" && Green == true) {
            Destroy(other.gameObject);
        }
	}
}
