using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float vel;

	public Rigidbody rbPlayer;

    private Vector3 mousePosition;
    private float distanceFromObject;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Moving();

       
	}

    void Moving(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rbPlayer.AddForce(movement * vel, ForceMode.VelocityChange);
    }
    
}
