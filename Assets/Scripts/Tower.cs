using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] float attackRange = 30f;



    private ParticleSystem projectileParticle;
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    private void Start()
    {
        projectileParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
	}

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);
        //print("distance is: " + distance);
        if (Mathf.Abs(distanceToEnemy) <= attackRange)
        {
            Shoot(true);
            print("close");
        }
        else {
            print("far");
            Shoot(false);

        }
    }

    private void Shoot(bool isActive)
    {
        var emmisionModule = projectileParticle.emission;
            emmisionModule.enabled = isActive;
    }
}
