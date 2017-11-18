using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;
    public float distanceToFollow;
    public float height;
    public float moveSpeed;
    private float rotationSpeed;
    private Vector3 point;
 
    private Ray targetRay;
 

        // Update is called once per frame
        void Update () {
        rotationSpeed = 1.0f;

        //move the camera into position behind the target
        targetRay = new Ray(target.position, -target.forward);
        point = targetRay.GetPoint(distanceToFollow);
        point = Vector3.Slerp(transform.position, point, Time.deltaTime * moveSpeed);
        transform.position = point;

        //rotate the camera to match the rotation of the target
        transform.LookAt(target, target.up);

    }
}
