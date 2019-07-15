using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PShoot : MonoBehaviour {

    public GameObject weapon;
    public GameObject bullet;
    public GameObject shootPoint;

    public Pistol pistolControl;
    public Shotgun shotgunControl;

    public Vector2 shootTarget;

	public float count;
	public float chrono;


    public Animator pAnim;
    public Animator pWeaponAnim;

	public int weaponType;

    public Vector3 mousePosition;

	public AudioSource shootgun;
    public AudioSource pistol;

    public string currentWeapon;
    public int currentWeaponMagazine;
    public int currentWeaponMaxMagazine;
    public float currentWeaponReload;

    public Text txtAmmo;
    public Text txtReload;

    public UI_Management UI_Call;

	void Start () {
        weapon = GameObject.FindGameObjectWithTag("pWeaponJoint");
        shootTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        count = 2;
        chrono = 2;

        weaponType = 0;
        currentWeapon = "AAAAA";
        currentWeaponMagazine = 12;
        currentWeaponMaxMagazine = 12;
        currentWeaponReload = 2;

        ChangeText();
	}
	
	// Update is called once per frame
	void Update () {
        WeaponAim();
        ChangeWeapon();
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
			switch (weaponType){
				case 0:
                    pistolControl.ShootingPistol();
					break;
                case 1:
                    shotgunControl.ShootingShotgun();
                    break;
				default:
                    pistolControl.ShootingPistol();
				break;
			}
            pAnim.SetTrigger("Shoot");
            pWeaponAnim.SetTrigger("Shoot");
        }
        count += Time.deltaTime;
	}

    void WeaponAim() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 looking = new Vector2(
            mousePosition.x - weapon.transform.position.x,
            mousePosition.y - weapon.transform.position.y
        );
        weapon.transform.up = looking;
    }

	public Vector3 FindMouse(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0.0f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition = mousePosition - transform.position;
		return mousePosition;
	}

	public void ChangeText(){
        if (weaponType == 0)
        {
            txtAmmo.text = "Ammo: "+pistolControl.Magazine+"/"+pistolControl.MaxMagazine;
        }
        if (weaponType == 1)
        {
            txtAmmo.text = "Ammo: " + shotgunControl.Magazine + "/" + shotgunControl.MaxMagazine;
        }
        txtReload.text = "";       
	}

    void ChangeWeapon(){
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UI_Call.WeaponSwap(0);
            weaponType = 0;
            currentWeapon = "Pistol";
            currentWeaponMagazine = pistolControl.Magazine;
            currentWeaponMaxMagazine = pistolControl.MaxMagazine;
            currentWeaponReload = pistolControl.timeReload;
            ChangeText();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            UI_Call.WeaponSwap(1);
            weaponType = 1;
            currentWeapon = "Shotgun";
            currentWeaponMagazine = shotgunControl.Magazine;
            currentWeaponMaxMagazine = shotgunControl.MaxMagazine;
            currentWeaponReload = shotgunControl.timeReload;
            ChangeText();
        }
    }
}
