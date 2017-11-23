using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public GameObject player;       //Public variable to store a reference to the player game object
    public float speed;

    void FixedUpdate() {
        transform.LookAt(player.transform);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
