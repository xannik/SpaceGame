using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarHelper : MonoBehaviour {

	private GameObject enemyDot;

	// Use this for initialization
	void Start () {
		GameObject radar = GameObject.FindGameObjectWithTag("Radar");

		GameObject templateDot = radar.transform.GetChild (0).gameObject;

		enemyDot = Object.Instantiate<GameObject> (templateDot,radar.transform);

		enemyDot.GetComponent<RadarDot> ().enemy = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onDestroy() {
		
		Destroy (enemyDot);

	}
}
