using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] float attackRange = 30f;
    private ParticleSystem projectileParticle;
    [SerializeField] Transform objectToPan;

    public Waypoint baseWaypoint;
   




    Transform targetEnemy;

    private void Start()
    {
        projectileParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length ==0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy,testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distToA= Mathf.Abs(Vector3.Distance(transform.position, transformA.position));
        float distToB = Mathf.Abs(Vector3.Distance(transform.position, transformB.position));

        if (distToA <= distToB)
        {
            return transformA;
        }
        return transformB;

    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);
        //print("distance is: " + distance);
        if (Mathf.Abs(distanceToEnemy) <= attackRange)
        {
            Shoot(true);
        }
        else {

            Shoot(false);

        }
    }

    private void Shoot(bool isActive)
    {
        var emmisionModule = projectileParticle.emission;
            emmisionModule.enabled = isActive;
    }
}
