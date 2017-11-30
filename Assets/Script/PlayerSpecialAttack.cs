using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour {

    // Use this for initialization

    public GameObject bulletPreFab1;
    public GameObject bulletPreFab2;
    public float fireDelay = 0.25f;
    private float cooldownTimer1 = 10;
    private float cooldownTimer2 = 5;

    void Start()
    {

    }

    void Update()
    {
        cooldownTimer1 -= Time.deltaTime;
        cooldownTimer2 -= Time.deltaTime;
        //  Debug.Log(Input.GetButton("Fire1"));

        if (Input.GetKeyDown(KeyCode.Alpha1) && cooldownTimer1 <= 0)
        {
            // Debug.Log("Pew!");
            cooldownTimer1 = fireDelay;
            Instantiate(bulletPreFab1, transform.position, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && cooldownTimer2 <= 0)
        {
            cooldownTimer2 = fireDelay;
            Instantiate(bulletPreFab2, transform.position, transform.rotation);
        }
    }
}
