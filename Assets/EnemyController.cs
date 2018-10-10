using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] List<BlockScript> path;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (BlockScript block in path)
		{
			print(block.name);
		}
	}
}
