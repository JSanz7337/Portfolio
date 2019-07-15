using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABoss : MonoBehaviour {

	public NavMeshAgent nmAgent;
	public GameObject goPlayer;

	void Start () {
		nmAgent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
            nmAgent.SetDestination(goPlayer.transform.position);        
	}
}
