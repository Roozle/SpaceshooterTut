using UnityEngine;
using System.Collections;

public class EnemyParams : MonoBehaviour {
	public float enemySpeed;
	public float enemyHealth;
	public float fireResistance;
	public float damageResistance;
	public GameObject attachedPrefab;
	public int priority;

	// Use this for initialization
	void Start () {
		//smallFastEnemy
		//set defaults
		enemySpeed = 2;
		enemyHealth = 100;
		fireResistance = 0.9f;
		damageResistance = 0.9f;
		attachedPrefab = this.gameObject;
		priority = 10;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.forward * 2.0F * Time.deltaTime;
	}
}
