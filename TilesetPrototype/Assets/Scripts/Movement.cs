using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    public Rigidbody2D rbPlayer;

    //Basic movement Variables
    private float vel = 300.00f;
    private Vector2 movement;

    //Dash Variables
    private float dashTime = 0.20f;
    private float dashCD = 3f;
    private Vector2 dashVel;
    private bool dash = true;
    private int dashForce = 5;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movement = new Vector2(Input.GetAxis("Horizontal")*vel, Input.GetAxis("Vertical")*vel);
        rbPlayer.velocity = movement*Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && dash) {
            StartCoroutine(DashMove(dashTime));
        }
    }

    IEnumerator DashMove(float dashDuration){
        float time = 0.00f;
        dash = false;
        dashVel = (movement*dashForce)*Time.deltaTime;

        while(dashDuration > time){
            time += Time.deltaTime;
            rbPlayer.velocity = dashVel;
            yield return 0;
        }
        yield return new WaitForSeconds(dashCD);
        dash = true;
    }
}
