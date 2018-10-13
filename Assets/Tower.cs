using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

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
}
