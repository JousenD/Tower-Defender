using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 2;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }


    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlesPrefab.Play();
    }

    private void KillEnemy()
    {
        ParticleSystem deathParticle = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        deathParticle.Play();
        Destroy(gameObject);
    }
}
