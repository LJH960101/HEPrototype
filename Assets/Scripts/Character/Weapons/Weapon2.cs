﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : WeaponBase
{
    GameObject bullet;
    const float power = 4500f;
    const float discardPosition = 10f;
    public override void Fire(MyShooter shooter)
    {
        if (bullet == null)
            bullet = Resources.Load<GameObject>("Prefabs/MyBullet2");
        base.Fire(shooter);
        GameObject newObj = GameObject.Instantiate(bullet);
        newObj.transform.position = shooter.shootPoint.position;
        newObj.GetComponent<Rigidbody>().AddForce(shooter.myCamera.transform.forward * power);
    }
    public override void Discard(MyShooter shooter)
    {
        base.Discard(shooter);
        GameObject weapon = Resources.Load<GameObject>("Prefabs/WeaponItem");
        weapon = GameObject.Instantiate(weapon);
        WeaponItem wi = weapon.GetComponent<WeaponItem>();
        if (wi) wi.SetWeaponCode(2);
        weapon.transform.position = shooter.transform.position +
            shooter.transform.up * discardPosition;
    }
}