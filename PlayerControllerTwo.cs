using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwo : MonoBehaviour {
    private float noTurn = 0.1f;
    private float factor = 150.0f;
    private Vector3 center;
    private Vector3 shipRot;

	// Use this for initialization
	void Start () {
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 delta = (Input.mousePosition - center) / Screen.height;
        Debug.Log(delta);
        shipRot = transform.GetChild(1).localEulerAngles;

        if (shipRot.x > 180) shipRot.x -= 360;
        if (shipRot.y > 180) shipRot.y -= 360;
        if (shipRot.z > 180) shipRot.z -= 360;

        if (delta.y > noTurn)
            transform.Rotate(-(delta.y - noTurn) * Time.deltaTime * factor, 0, 0);
        if (delta.y < -noTurn)
            transform.Rotate(-(delta.y + noTurn) * Time.deltaTime * factor, 0, 0);
        if (delta.x > noTurn)
            transform.Rotate(0, (delta.x - noTurn) * Time.deltaTime * factor, 0);
        if (delta.x < -noTurn)
            transform.Rotate(0, (delta.x + noTurn) * Time.deltaTime * factor, 0);

    }
}
