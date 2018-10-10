using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

	[Range(1f, 20f)][SerializeField] float gridSize = 10f;
	TextMesh textMesh;
	Vector3 snapPos;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		CubeSnapping();

		LabelWriting();
	}

	private void LabelWriting()
	{
		textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text = snapPos.x/gridSize + "," + snapPos.z/gridSize;
	}

	private void CubeSnapping()
	{
		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
	}
}
