using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object
    public GameObject shotPrefab;
    public float speed = 10f;
    public float turnspeed = 1.5f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    void ShootPlayer()
    {
        Vector3 relativePoint = transform.InverseTransformPoint(player.transform.position);

        Debug.Log(relativePoint.x);

        if (relativePoint.x < 5.0 &&
            relativePoint.x > -5.0 &&
            Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject go = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(go, 3f);
        }
    }

    void rotateToPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
    }

    void moveForward()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update() {
        rotateToPlayer();
        moveForward();
        ShootPlayer();
    }
}