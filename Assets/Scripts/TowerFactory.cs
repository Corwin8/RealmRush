using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] TowerController placeableTower;
	[SerializeField] Transform towerParentTransform;


	Queue<TowerController> towersInScene = new Queue<TowerController>();


	public void AddTower(Waypoint baseWaypoint)
	{
		if (towersInScene.Count < towerLimit)
		{
			InstantiateTower(baseWaypoint);
		}
		else
		{
			MoveExistingTower(baseWaypoint);
		}

	}

	private void InstantiateTower(Waypoint baseWaypoint)
	{
		var newTower = Instantiate(placeableTower, baseWaypoint.transform.position, Quaternion.identity);
		newTower.transform.parent = towerParentTransform;
		towersInScene.Enqueue(newTower);
		baseWaypoint.isPlaceable = false;
		newTower.baseWaypoint = baseWaypoint;
	}

	private void MoveExistingTower(Waypoint baseWaypoint)
	{
		var oldTower = towersInScene.Dequeue();
		oldTower.baseWaypoint.isPlaceable = true;
		baseWaypoint.isPlaceable = false;
		oldTower.baseWaypoint = baseWaypoint;
		oldTower.transform.position = baseWaypoint.transform.position;
		towersInScene.Enqueue(oldTower);
	}
}
