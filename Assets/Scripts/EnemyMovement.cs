using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;
    [SerializeField] float enemyMoveSpeed = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

	// Use this for initialization
	void Start ()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();

        print(path);
        StartCoroutine(FollowPath(path));
    }



    IEnumerator FollowPath(List<Waypoint> path)
    {
        
        foreach (Waypoint waypoint in path)
        {
            
            transform.position = waypoint.transform.position;
            
            yield return new WaitForSeconds(enemyMoveSpeed);
            
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        ParticleSystem deathParticle = Instantiate(goalParticle, transform.position, Quaternion.identity);
        deathParticle.Play();

        Destroy(deathParticle.gameObject, deathParticle.main.duration);
        Destroy(gameObject);
    }

}
