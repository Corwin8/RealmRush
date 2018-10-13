using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	[SerializeField] public int towerDamage = 5;
	[SerializeField] Transform gunToRotate;
	[SerializeField] Transform enemyToLookAt;
	[SerializeField] ParticleSystem projectileParticle;
	[SerializeField] float attackRange = 30f;



	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (enemyToLookAt)
		{
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}
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
