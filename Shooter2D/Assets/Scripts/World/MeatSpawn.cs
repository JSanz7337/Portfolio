using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatSpawn : MonoBehaviour {

    public GameObject meat;
    private GameObject spawnMeat;

    public bool Active;

    public float Chrono;

    void Start() {
        Active = false;
        Chrono = -15;
    }

    // Update is called once per frame
    void Update() {

        Chrono += Time.deltaTime;
        
        if (Active == true && Chrono <= 0) {
            Destroy(spawnMeat, 15.0f);
            Active = false;
        }
        if (Chrono >= 15) {

            spawnMeat = (GameObject)Instantiate(meat, this.transform.position, meat.transform.rotation);

            Active = true;
            Chrono = -15;
        }
    }
}
