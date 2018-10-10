using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] List<Waypoint> path;


	// Use this for initialization
	void Start()
	{
		StartCoroutine(FollowPath());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator FollowPath()
	{
		print("Starting patrol.");
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			print("I`m currently patroling on coordinates " + waypoint.name);
			yield return new WaitForSeconds(1f);
		}
		print("I arrived at the patroling destination.");
	}
}
