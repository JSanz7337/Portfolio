using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

	public PShoot shootControl;
    public UI_Management UI_Call;

    public float bulletVel;
    public float reload = 0;
    public float timeReload = 2;

    public int Magazine;
    public int MaxMagazine = 12;

    bool reloadTime = false;
	// Use this for initialization
	void Start () {
		bulletVel = 8;
        Magazine = 12;
	}
	
	// Update is called once per frame
	void Update () {
		if (reloadTime)
        {
            UI_Call.ReloadWepon();
            Reload();
        }
	}

    public void ShootingPistol()
    {
        if (!reloadTime)
        {
            Debug.Log("Piun");
            shootControl.mousePosition = shootControl.FindMouse();

            if (Magazine <= 0)
            {
                reloadTime = true;
            }
            else
            {
                GameObject bulletSpawn = (GameObject)Instantiate(shootControl.bullet, shootControl.shootPoint.transform.position, shootControl.shootPoint.transform.rotation);
                bulletSpawn.GetComponent<Rigidbody>().velocity = shootControl.shootPoint.transform.up * bulletVel;

                Destroy(bulletSpawn, 2.0f);
                shootControl.count = 0;
                shootControl.pistol.Play();
                Magazine -= 1;

                shootControl.ChangeText();
            }
        }
    }

    public void Reload()
    {
        reload += Time.deltaTime;
        if (reload >= timeReload)
        {
            reload = 0;
            Magazine = MaxMagazine;
            shootControl.ChangeText();
            reloadTime = false;
        }  
    }
}
