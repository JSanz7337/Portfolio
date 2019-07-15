using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour {

	public Rigidbody rbPlayer;

	public float jumpForce;
	public float vel;

	public bool grounded;

    public Animator pAnim;
    public Animator pAnim2;

	void Start () {
		jumpForce = 8;
		vel = 5;
		rbPlayer = this.GetComponent<Rigidbody>();
	}
	
	void Update () {
		Moving();
		Jumping();
	}

	void Moving(){
        if (Input.GetKey(KeyCode.A)) {
            this.transform.Translate(-vel * Time.deltaTime, 0, 0, Space.World);
            pAnim.SetTrigger("Moving");
            pAnim2.SetTrigger("MoveL");
        }
        if (Input.GetKey(KeyCode.D)) {
            this.transform.Translate(vel * Time.deltaTime, 0, 0, Space.World);
            pAnim.SetTrigger("Moving");
            pAnim2.SetTrigger("MoveR");
        }
	}

	void Jumping(){
        grounded = false;

        RaycastHit rcJump;
        if (Physics.Raycast(this.transform.position, Vector3.down, out rcJump, 0.51f)) {
            grounded = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true) {
            rbPlayer.velocity = Vector3.up * jumpForce;
        }
	}

	
}
