using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2, Waypoint> grid = new Dictionary<Vector2, Waypoint>();

	// Use this for initialization
	void Start () {
		LoadBlocks();
	}

	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			Vector2Int gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Overlaping block " + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
			}
		}

		print(grid.Count);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
