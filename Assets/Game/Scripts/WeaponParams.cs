using UnityEngine;
using System.Collections;

public class singleCannonParams : MonoBehaviour {

	public float weaponDamage;
	public float weaponSpeed;
	public float barrelRotationSpeed;
	public GameObject attachedPrefab;
	public float priceToUpgrade;
	public float priceToSell;
	public float priceToBuy;


	// Use this for initialization
	void Start () {
		//CANNON
		//set defaults
		weaponDamage = 1;
		weaponSpeed = 0.33f;
		barrelRotationSpeed = 0.1f;
		attachedPrefab = this.gameObject;
		priceToUpgrade =30;
		priceToSell = 6;
		priceToBuy = 15;

	}
}