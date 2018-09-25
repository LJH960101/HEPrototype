using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject endEffect;
    const float lifeTime = 3.0f;
    float currentLifeTime;

    // Use this for initialization
    void Start ()
    {
        currentLifeTime = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateLifeTime();
    }
    void UpdateLifeTime()
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime > lifeTime) Destroy(this);
    }
}
