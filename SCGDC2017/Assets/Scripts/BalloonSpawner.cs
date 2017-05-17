using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

    public GameObject balloonPrefab;

    public float minSpawnWait = 0.5f;
    public float maxSpawnWait = 2.0f;
    public float lifeTime = 20.0f;

    private Vector3 extents;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnBalloons());
        extents = GetComponent<BoxCollider>().bounds.extents;

    }
	
    private IEnumerator SpawnBalloons()
    {
        while (true)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(Random.Range(minSpawnWait, maxSpawnWait));
        }
    }

    private void SpawnBalloon()
    {
        float x = Random.Range(-extents.x, extents.x);
        float y = -extents.y + 0.2f;
        float z = Random.Range(-extents.z, extents.z);

        Vector3 spawnPosition = transform.position + new Vector3(x, y, z);

        float xRot = Random.Range(-45, 45);
        float yRot = Random.Range(-45, 45);

        Quaternion spawnRotation = Quaternion.Euler(xRot, 0, yRot);

        GameObject balloon = Instantiate(balloonPrefab, spawnPosition, spawnRotation);
        Destroy(balloon, lifeTime);
    }
}
