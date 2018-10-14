using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] TowerController placeableTower;


	Queue<TowerController> towersInScene = new Queue<TowerController>();


	public void AddTower(Waypoint baseWaypoint)
	{
		if (towersInScene.Count < towerLimit)
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
		var tower = Instantiate(placeableTower, baseWaypoint.transform.position, Quaternion.identity);
		towersInScene.Enqueue(tower);
		print("Towers in queue: " + towersInScene.Count);
		baseWaypoint.isPlaceable = false;
	}

	private void MoveExistingTower()
	{
		var oldTower = towersInScene.Dequeue();

		towersInScene.Enqueue(oldTower);
	}
}
