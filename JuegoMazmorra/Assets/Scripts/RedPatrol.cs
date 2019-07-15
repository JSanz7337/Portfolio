using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedPatrol : MonoBehaviour {

    public NavMeshAgent nmAgent;
    Vector3 patrolDirection;
    int RedDest = 1;
    public GameObject goPlayer;
    Vector3 playerDirection;
    public float Distance;
    public GameObject patrol1, patrol2;
    float margin = 1;

	void Start () {
        nmAgent = this.GetComponent<NavMeshAgent>();
	}

    void Update() {
        Patrol();
    }
    void Patrol() {
        playerDirection = goPlayer.transform.position - this.transform.position;
        patrolDirection = this.transform.position - nmAgent.destination;
        if (playerDirection.magnitude < Distance) {
            nmAgent.SetDestination(goPlayer.transform.position);
        }
        if (patrolDirection.magnitude < margin) {
            switch (RedDest) {
                case 2:
                    nmAgent.SetDestination(patrol2.transform.position);
                    RedDest = 1;
                    break;
                case 1:
                    nmAgent.SetDestination(patrol1.transform.position);
                    RedDest++;
                    break;
                default:
                    nmAgent.SetDestination(patrol1.transform.position);
                    RedDest = 1;
                    break;
            }
        }
    }
}
