using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2, Waypoint> grid = new Dictionary<Vector2, Waypoint>();
	[SerializeField] Waypoint startBlock;
	[SerializeField] Waypoint endBlock;

	// Use this for initialization
	void Start() {
		LoadBlocks();
		ColorStartAndEnd();
	}

	private void ColorStartAndEnd()
	{
		startBlock.SetTopColor(Color.magenta);
		endBlock.SetTopColor(Color.black);
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
				waypoint.SetTopColor(Color.grey);
				grid.Add(gridPos, waypoint);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
