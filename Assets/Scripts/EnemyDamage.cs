using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] int currentHP;
	[SerializeField] int maxHP = 100;
	TowerController tower;
	[SerializeField] Collider hitCollider;


	[SerializeField] GameObject hitEffect;
	GameObject hitFX;

	[SerializeField] GameObject deathEffect;
	GameObject deathFX;

	// Use this for initialization
	void Start ()
	{
		tower = FindObjectOfType<TowerController>();
		currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DecreaseHP()
	{
		currentHP = currentHP - tower.towerDamage;
		if (currentHP <= 0)
		{
			KillEnemy();
		}
	}

	private void KillEnemy()
	{
		deathFX = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnParticleCollision(GameObject other)
	{
		DecreaseHP();
		hitFX = Instantiate(hitEffect, transform.position, Quaternion.identity);
	}
}
