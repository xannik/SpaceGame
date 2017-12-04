using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
	public Camera currentCamera;

	public Camera spaceShipCamera;
	public Camera gunCamera;
    public MouseCamera script;
	// Use this for initialization
	void Start () {
		spaceShipCamera.enabled = true;
		gunCamera.enabled = false;
        script = GetComponent<MouseCamera>();
        script.enabled = false;

		currentCamera = spaceShipCamera;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            spaceShipCamera.enabled = !spaceShipCamera.enabled;
            gunCamera.enabled = !gunCamera.enabled;
            script.enabled = !script.enabled;

			currentCamera = gunCamera.enabled ? gunCamera : spaceShipCamera;
        }
       
	}
}
