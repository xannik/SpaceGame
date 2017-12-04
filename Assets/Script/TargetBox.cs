using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : MonoBehaviour {
	private SwitchCamera switchCamera;

	private const float factor = 0.025f;

	void Start () {
		GameObject cannon = GameObject.FindGameObjectWithTag("Cannon");
		switchCamera = cannon.GetComponent<SwitchCamera> ();
	}
	
	void Update () {

		Transform camTransform = switchCamera.currentCamera.transform;

		transform.rotation = camTransform.rotation;

		Vector3 direction = transform.position - camTransform.position;

		float scale = factor * direction.magnitude;

		transform.localScale = new Vector3(scale, scale, scale);
	}
}