using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawn = 4f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }
	

    IEnumerator SpawnEnemy(EnemyMovement enemy)
    {
        while (true)
        {
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
