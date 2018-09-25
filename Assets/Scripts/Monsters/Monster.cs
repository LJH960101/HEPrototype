using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    protected Animator anim;
    protected GameObject _player;
    public float hp;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        hp = 10f;
	}

    public void PerceptionPlayer(GameObject player)
    {
        anim.SetBool("bOnSee", true);
        _player = player;
    }

    public void OnDamage(float damage)
    {
        hp -= damage;
        anim.SetFloat("HP", hp);
    }

    public void UnperceptionPlayer()
    {
        anim.SetBool("bOnSee", false);
        _player = null;
    }
}
