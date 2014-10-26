using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float enemySpeed;

	// Use this for initialization
	void Start () {

	this.GetComponent ("smallEnemyParams");
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.forward * Time.deltaTime * 2;
	
	}
}
