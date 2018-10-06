using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawn = 4f;
    [SerializeField] GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }
	

    IEnumerator SpawnEnemy(GameObject enemy)
    {
        while (true)
        {
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
