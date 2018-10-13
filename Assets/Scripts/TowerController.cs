using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

	[SerializeField] public int towerDamage = 5;
	[SerializeField] Transform gunToRotate;
	[SerializeField] Transform enemyToLookAt;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		LookAtEnemy();
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
