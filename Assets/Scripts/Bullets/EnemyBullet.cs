using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    const float attackKnockbackPower = 10000f;
    private void OnTriggerEnter(Collider other)
    {
        // 강체만 체크한다.
        if (other.isTrigger) return;
        // 몬스터 끼리의 총알 충돌은 불허한다.
        if (other.gameObject.tag == "Monster") return;

        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if(rb) rb.AddForce(transform.forward * attackKnockbackPower +
                new Vector3(0f, attackKnockbackPower, 0f));
        }
        Instantiate(endEffect).transform.position = transform.position;
        Destroy(gameObject);
    }
}
