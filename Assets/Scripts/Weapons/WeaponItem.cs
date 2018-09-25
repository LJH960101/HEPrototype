using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {
    public int weaponCode = 0;
    const int weaponLimit = 2;
    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어에게 웨폰을 증정하고 기존 웨폰을 해제 시킨다.
        if(collision.gameObject.tag == "Player")
        {
            MyShooter shooter = collision.gameObject.GetComponent<MyShooter>();
            if (shooter != null)
            {
                shooter.myWeapon.Discard(shooter);
                shooter.myWeapon = CreateWeapon();
                Destroy(gameObject);
            }
        }
    }
    public void SetWeaponCode(int code)
    {
        if(code <= 0 || code >= weaponLimit + 1)
        {
            print("Not enough code!!");
            return;
        }
        weaponCode = code;
    }
    WeaponBase CreateWeapon()
    {
        switch (weaponCode)
        {
            case 1:
                return new Weapon1();
            case 2:
                return new Weapon2();
            default:
                print("Unkown Weapon Code!!");
                return null;
        }
    }
}
