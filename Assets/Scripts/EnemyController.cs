using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] int maxHP = 100;
	TowerController tower;
	[SerializeField] int currentHP;


	[SerializeField] GameObject hitEffect;
	GameObject hitFX;

	[SerializeField] GameObject deathEffect;
	GameObject deathFX;

	// Use this for initialization
	void Start()
	{
		tower = FindObjectOfType<TowerController>();
		currentHP = maxHP;
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		var path = pathfinder.GetPath();
		StartCoroutine(FollowPath(path));
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	IEnumerator FollowPath(List<Waypoint> path)
	{
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
		}
		print("I arrived at the patroling destination.");
	}

	public void DecreaseHP()
	{
		currentHP = currentHP - tower.towerDamage;
		if (currentHP <= 0)
		{
			KillEnemy();
		}
	}

	private void KillEnemy()
	{
		deathFX = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public void OnParticleCollision(GameObject other)
	{
		DecreaseHP();
		hitFX = Instantiate(hitEffect, transform.position, Quaternion.identity);

	}
}
