using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float MaxSpeed = 5f;
    Vector3 velocity;
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        velocity = new Vector3(0, -MaxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
	}
}
