using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawn = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnEnemySFX;
    int count = 0;

	// Use this for initialization
	void Start () {
        spawnedEnemies.text = count.ToString();
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }
	

    IEnumerator SpawnEnemy(EnemyMovement enemy)
    {
        while (true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    private void AddScore()
    {
        count++;
        spawnedEnemies.text = count.ToString();
    }
}
