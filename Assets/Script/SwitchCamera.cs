using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
	public Camera currentCamera;
    public GameObject gobject;
    
	public Camera spaceShipCamera;
	public Camera gunCamera;
    public MouseCamera script;

    private Renderer rend;
    public GameObject cannon;
    public GameObject spaceship;
    private Quaternion angle;
    // Use this for initialization
    void Start () {
		spaceShipCamera.enabled = true;
		gunCamera.enabled = false;
        script = GetComponent<MouseCamera>();
        script.enabled = false;
        rend = gobject.GetComponent<Renderer>();
		currentCamera = spaceShipCamera;
        cannon.transform.localRotation = Quaternion.Euler(spaceship.transform.rotation.x, spaceship.transform.rotation.y + 180, spaceship.transform.rotation.z);
        
    }
	
	// Update is called once per frame
	void Update () {
        angle = spaceship.transform.rotation;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rend.enabled = !rend.enabled;
            spaceShipCamera.enabled = !spaceShipCamera.enabled;
            gunCamera.enabled = !gunCamera.enabled;
            //Cursor.visible = false;
            if (gunCamera.enabled == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
            cannon.transform.localRotation = Quaternion.Euler(angle.x, (angle.y + 180) % 360, angle.z);
        
            
            script.enabled = !script.enabled;
            
			currentCamera = gunCamera.enabled ? gunCamera : spaceShipCamera;
        }
       
	}
}
