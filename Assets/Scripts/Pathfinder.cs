using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2, Waypoint> grid = new Dictionary<Vector2, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();

	[SerializeField] Waypoint startWaypoint;
	[SerializeField] Waypoint endWaypoint;
	public List<Waypoint> path;

	bool isSearching = true;

	Waypoint searchCenter;

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
		FindPath();
		//ExploreNeighbourgs();
	}

	private void FindPath()
	{
		queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isSearching)
		{
			searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
			print("Searching from: " + searchCenter);
			HaltIfEndFound();
			ExploreNeighbourgs();
		}
	}

	private void HaltIfEndFound()
	{
		if (searchCenter == endWaypoint)
		{
			print("You have arrived at End Point on: " + searchCenter);
			isSearching = false;
		}
	}

	private void ExploreNeighbourgs()
	{
		if (!isSearching) { return; }

		foreach (Vector2Int direction in directions)
		{
			Vector2Int exploredBlock = direction + searchCenter.GetGridPos();
			try
			{
				QueueNewNeighbours(exploredBlock);
			}
			catch
			{
				Debug.LogWarning("Explored block is not in dictionary " + exploredBlock); 
			}
		};
	}

	private void QueueNewNeighbours(Vector2Int exploredBlock)
	{
		Waypoint neighbour = grid[exploredBlock];
		if (neighbour.isExplored || queue.Contains(neighbour))
		{
			//do nothing
		}
		else
		{
			queue.Enqueue(neighbour);
			neighbour.exploredFrom = searchCenter;
			print("Queueing " + neighbour);
		}
	}

	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.magenta);
		endWaypoint.SetTopColor(Color.black);
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
