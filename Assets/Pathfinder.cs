using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2, Waypoint> grid = new Dictionary<Vector2, Waypoint>();
	[SerializeField] Waypoint startBlock;
	[SerializeField] Waypoint endBlock;

	Vector2Int[] directions =
		{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
		};

	// Use this for initialization
	void Start() {
		LoadBlocks();
		ColorStartAndEnd();
		ExploreNeighbourgs();
	}

	private void ExploreNeighbourgs()
	{
		foreach (Vector2Int direction in directions)
		{
			Vector2Int exploredBlock = direction + startBlock.GetGridPos();
			try
			{
				grid[exploredBlock].SetTopColor(Color.green);
			}
			catch
			{
				Debug.LogWarning("Explored block is not in dictionary " + exploredBlock); 
			}
		};
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
				//waypoint.SetTopColor(Color.grey);
				grid.Add(gridPos, waypoint);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
