using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Headquaters : MonoBehaviour {

	[SerializeField] int headquartersHP = 10;
	[SerializeField] Text healthText;

	private void Start()
	{
		healthText.text = headquartersHP.ToString();
	}

	private void OnTriggerEnter(Collider other)
	{
		print("Trigger entered.");
		headquartersHP--;
		healthText.text = headquartersHP.ToString();
		if (headquartersHP <= 0)
		{
			Destroy(gameObject, 1f);
		}
	}
}
