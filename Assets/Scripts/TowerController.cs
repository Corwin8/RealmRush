﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	//parameters
	[SerializeField] public int towerDamage = 5;
	[SerializeField] Transform gunToRotate;
	[SerializeField] ParticleSystem projectileParticle;
	[SerializeField] float attackRange = 30f;

	public Waypoint baseWaypoint;

	//state
	Transform enemyToLookAt;



	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		SetTargetEnemy();

		if (enemyToLookAt)
		{
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}
	}

	private void SetTargetEnemy()
	{
		var sceneEnemies = FindObjectsOfType<EnemyController>();
		if (sceneEnemies.Length == 0) { return; }

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyController enemy in sceneEnemies)
		{
			closestEnemy = GetClosest(closestEnemy, enemy.transform);
		}

		//choose closest enemy

		enemyToLookAt = closestEnemy;
	}

	private Transform GetClosest(Transform transformA, Transform transformB)
	{
		var distToA = Vector3.Distance(transform.position, transformA.transform.position);
		var distToB = Vector3.Distance(transform.position, transformB.transform.position);

		if (distToA <= distToB)
		{
			return transformA;
		}
		return transformB;
	}

	private void FireAtEnemy()
	{
		float distanceToEnemy = Vector3.Distance(enemyToLookAt.transform.position, gunToRotate.transform.position);
		Shoot(true);
		if (distanceToEnemy <= attackRange)
		{
			Shoot(true);
			LookAtEnemy();
		}
		else
		{
			Shoot(false);
		}
	}

	private void Shoot(bool isActive)
	{
		var emissionsModule = projectileParticle.emission;
		emissionsModule.enabled = isActive;
	}

	private void LookAtEnemy()
	{
		gunToRotate.LookAt(enemyToLookAt);
	}

	public int GetTowerDamage(int damage)
	{
		return towerDamage;
	}
}
