using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] EnemyController enemyPrefabToSpawn;
	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] Transform enemyParentTransform;
	[SerializeField] Text scoreText;
	int score = 0;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies()
	{
		while (true) //forever
		{
			var newEnemy = Instantiate(enemyPrefabToSpawn, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;

			score++;
			scoreText.text = score.ToString();

			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
