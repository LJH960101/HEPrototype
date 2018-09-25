using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPerception : MonoBehaviour {
    Monster monster;
    private void Start()
    {
        monster = transform.parent.GetComponent<Monster>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            monster.PerceptionPlayer(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monster.UnperceptionPlayer();
        }
    }
}
