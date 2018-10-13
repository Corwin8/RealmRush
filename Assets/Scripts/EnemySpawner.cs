using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] EnemyController enemyPrefabToSpawn;
	[SerializeField] float secondsBetweenSpawns = 2f; 

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies()
	{
		while (true) //forever
		{
			Instantiate(enemyPrefabToSpawn, new Vector3(0, 0, 0), Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
