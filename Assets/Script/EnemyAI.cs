using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object
    public float speed;
    public float turnspeed;

    void Update() {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}