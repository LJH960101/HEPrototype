using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : Bullet {
    public float damage = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        // 강체만 체크한다.
        if (other.isTrigger) return;

        if(other.gameObject.tag == "Monster")
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.OnDamage(damage);
            }
        }
        Instantiate(endEffect).transform.position = transform.position;
        Destroy(this);
    }
}
