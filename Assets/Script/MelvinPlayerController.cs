using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelvinPlayerController : MonoBehaviour {

    public float speed = 10f;
    public float speedChange = 10f;
    public float speedMax = 300f;
    public float speedMin = 0f;
    public float turnSpeed = 2f;
    public float RotateSpeed = 1.5f;
    public float fireRate = 0.5f;
    public GameObject shotPrefab;

    private float nextFire = 0.0f;

    void movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, 0, 1), RotateSpeed);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0, -1), RotateSpeed);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.Rotate(new Vector3(1, 0, 0), turnSpeed);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(-1, 0, 0), turnSpeed);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void changeSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed += speedChange * Time.deltaTime;
        else
            speed -= speedChange * Time.deltaTime;
        speed = (speed > speedMax ? speedMax : (speed < speedMin ? speedMin : speed));
    }
        
    /*void shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject go = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
        
    }*/

    void FixedUpdate()
    {
        changeSpeed();
        movement();
        //shoot();
    }
}
