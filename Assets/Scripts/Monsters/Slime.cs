using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster {
    private NavMeshAgent nav;
    const float attackRange = 2.5f;
    const float attackKnockbackPower = 10000f;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        hp = 10f;
	}

	// Update is called once per frame
	void Update () {
        // 죽었다면 움직이지마!
        if(hp <= 0f)
        {
            nav.isStopped = true;
            return;
        }

        // 살았다면 각자의 업데이트를 수행.
        anim.SetFloat("velocity", nav.velocity.magnitude);
        if (_player != null) UpdateOnSee();
        else UpdateLooking();
	}

    void UpdateOnSee()
    {
        // 거리가 멀면 가까이 간다.
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        anim.SetFloat("distance", distance);
        if(distance >= attackRange)
        {
            nav.isStopped = false;
            nav.SetDestination(_player.transform.position);
        }
        else
        {
            // 공격 처리
            nav.isStopped = true;
            transform.LookAt(_player.transform);
        }
    }

    void UpdateLooking()
    {
        // 쫒아갈때의 처리. 딱히 할건 없는듯.
    }

    void Attack()
    {
        if (_player == null) return;
        // 가까이 있으면 날아감
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance <= 3.0f)
        {
            _player.GetComponent<Rigidbody>().AddForce(transform.forward * attackKnockbackPower + 
                new Vector3(0f, attackKnockbackPower, 0f));
        }
    }
}