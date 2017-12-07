using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour {

    public int speed = 1;
    public GameObject Sun = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(Sun.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
