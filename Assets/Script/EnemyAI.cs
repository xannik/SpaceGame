using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject player = null;       //Public variable to store a reference to the player game object
    public GameObject shotPrefab = null;
    public float speed = 10f;
    public float turnspeed = 1.5f;
    public float fireRate = 0.5F;
    public float rayCastOffset = 10f;
    public float detectionDistance = 100f;

    private float nextFire = 0.0F;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void ShootPlayer()
    {
        Vector3 relativePoint = transform.InverseTransformPoint(player.transform.position);

        //Debug.Log(relativePoint.x);

        if (relativePoint.x < 5.0 &&
            relativePoint.x > -5.0 &&
            Time.time > nextFire)
        {
            if (shotPrefab == null)
                Debug.Log("SHotPrefab == null");
            else {
                nextFire = Time.time + fireRate;
                GameObject go = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation) as GameObject;
                GameObject.Destroy(go, 3f);
            }
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

    void pathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistance, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
            raycastOffset += Vector3.right;
        else if(Physics.Raycast(right, transform.forward, out hit, detectionDistance))
            raycastOffset -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
            raycastOffset += Vector3.up;
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
            raycastOffset -= Vector3.up;

        if (raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 10f * Time.deltaTime);
        else
            rotateToPlayer();

    }

    void Update() {
        if (player != null)
        {
            pathFinding();
            moveForward();
            ShootPlayer();
        }
        else
            Debug.Log("Player == null");

    }
}