using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : MonoBehaviour {

	private const float factor = 0.02f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Camera.main.transform.rotation;

		Vector3 direction = transform.position - Camera.main.transform.position;

		float scale = factor * direction.magnitude;

		transform.localScale = new Vector3(scale, scale, scale);
	}
}