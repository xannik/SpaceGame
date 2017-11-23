using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public GameObject shotPrefab;

    void FixedUpdate() {
        float current_speed = speed;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            transform.Rotate(new Vector3(0, 0, 1), turnSpeed);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0, -1), turnSpeed);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
            transform.Rotate(new Vector3(1, 0, 0), turnSpeed);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(-1, 0, 0), turnSpeed);
        if (Input.GetKey(KeyCode.LeftShift))
            current_speed *= 15;
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject go = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
        GetComponent<Rigidbody>().velocity = transform.forward * current_speed;
    }
}
