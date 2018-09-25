using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShooter : MonoBehaviour {
    public GameObject myCamera;
    public Transform shootPoint;
    public WeaponBase myWeapon;
    private void Start()
    {
        myWeapon = new Weapon1();
    }
    void Update () {
        if (Input.GetButtonDown("Fire"))
        {
            Fire();
        }
	}
    void Fire()
    {
        myWeapon.Fire(this);
    }
}
