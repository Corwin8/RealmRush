using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] TowerController placeableTower;


	public void AddTower(Waypoint baseWaypoint)
	{
		var towersInScene = FindObjectsOfType<TowerController>();
		if (towersInScene.Length < towerLimit)
		{
			InstantiateTower(baseWaypoint);
		}
		else
		{
			MoveExistingTower();
		}

	}



	private void InstantiateTower(Waypoint baseWaypoint)
	{
		Instantiate(placeableTower, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.isPlaceable = false;
	}

	private void MoveExistingTower()
	{
		throw new NotImplementedException();
	}
}
