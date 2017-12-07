using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarHelper : MonoBehaviour {

	private GameObject enemyDot;

	public GameObject template;

	// Use this for initialization
	void Start () {
		GameObject radar = GameObject.FindGameObjectWithTag("Radar");

		enemyDot = Object.Instantiate<GameObject> (template,radar.transform);

		enemyDot.GetComponent<RadarDot> ().enemy = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onDestroy() {
		
		Destroy (enemyDot);
	}
}
