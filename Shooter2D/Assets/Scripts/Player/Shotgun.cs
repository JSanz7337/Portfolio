using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

    public PShoot shootControl;
    public UI_Management UI_Call;

    public float bulletVel;
    public float reload;
    public float timeReload = 4;

    public int Magazine;
    public int MaxMagazine = 4;

    bool reloadTime = false;

	// Use this for initialization
	void Start () {
		bulletVel = 8;
        Magazine = 4;
	}
	
	// Update is called once per frame
	void Update () {
        if (reloadTime)
        {
            UI_Call.ReloadWepon();
            Reload();
        }
	}

    public void ShootingShotgun()
    {
        if (!reloadTime)
        {
            shootControl.mousePosition = shootControl.FindMouse();

            if (Magazine <= 0)
            {
                reloadTime = true;
            }
            else
            {
                if (shootControl.count >= 2)
                {
                    GameObject bulletSpawn;
                    for (int i = 0; i < 5; i++)
                    {  
                        bulletSpawn = (GameObject)Instantiate(shootControl.bullet, shootControl.shootPoint.transform.position, shootControl.shootPoint.transform.rotation);
                        bulletSpawn.GetComponent<Rigidbody>().velocity = shootControl.shootPoint.transform.up * bulletVel;
                        Destroy(bulletSpawn, 1.5f);
                    }
                    shootControl.count = 0;
                    shootControl.shootgun.Play();
                    Magazine -= 1;
                    shootControl.ChangeText();
                }
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
