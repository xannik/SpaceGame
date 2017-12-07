using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    private Transform T;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    void Start()
    {
        reset();
            
    }
    public void reset ()
    {
        T = transform.GetComponentInParent<Transform>();
        Debug.Log("T: " + T);
        Vector3 rot = T.localEulerAngles;

        transform.rotation = T.localRotation;

       // transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        rotY = 180;// rot.y;
        rotX = 0; //rot.x;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;
    }
}
