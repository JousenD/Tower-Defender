using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 2;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlesPrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
        myAudioSource = GetComponent<AudioSource>();

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
        myAudioSource.PlayOneShot(enemyHitSFX);

    }

    private void KillEnemy()
    {
        ParticleSystem deathParticle = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
        deathParticle.Play();
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(deathParticle.gameObject, deathParticle.main.duration);
        Destroy(gameObject);
    }
}
