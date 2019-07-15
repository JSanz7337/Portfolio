using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BluePatrol : MonoBehaviour {

    public NavMeshAgent nmAgent;
    Vector3 patrolDirection;
    int BlueDest = 1;
    public GameObject goPlayer;
    Vector3 playerDirection;
    public float Distance;
    public GameObject patrol1, patrol2, patrol3, patrol4;
    float margin = 1;

	void Start () {
        nmAgent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        Patrol();
	}
	void Patrol() {
        playerDirection = goPlayer.transform.position - this.transform.position;
        patrolDirection = this.transform.position - nmAgent.destination;
        if (playerDirection.magnitude < Distance)
        {
            nmAgent.SetDestination(goPlayer.transform.position);
        }
        if (patrolDirection.magnitude < margin) {
            switch (BlueDest) {
                case 4:
                    nmAgent.SetDestination(patrol4.transform.position);
                    BlueDest = 1;
                    break;
                case 3:
                    nmAgent.SetDestination(patrol3.transform.position);
                    BlueDest++;
                    break;
                case 2:
                    nmAgent.SetDestination(patrol2.transform.position);
                    BlueDest++;
                    break;
                case 1:
                    nmAgent.SetDestination(patrol1.transform.position);
                    BlueDest++;
                    break;
                default:
                    nmAgent.SetDestination(patrol1.transform.position);
                    BlueDest = 2;
                    break;
            }
        }
	}
}
