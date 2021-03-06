﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	public bool isExplored = false;
	public Waypoint exploredFrom;
	[SerializeField] Color exploredColor = Color.magenta;

	public bool isPlaceable = true;

	Vector2Int gridPos;
	const int gridSize = 10;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (isExplored)
		{
			SetTopColor(exploredColor);
			return;
		}
		else
		{
			//do nothing
		}*/

	}

	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x/gridSize),
			Mathf.RoundToInt(transform.position.z/gridSize));
	}

	public void SetTopColor(Color color)
	{
		
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && isPlaceable)
		{
			FindObjectOfType<TowerFactory>().AddTower(this);
		}
	}

}
