﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	// Use this for initialization
	void Start()
	{
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
			yield return new WaitForSeconds(0.5f);
		}
		KillEnemy();
	}
	private void KillEnemy()
	{
		Destroy(gameObject);
	}
}
