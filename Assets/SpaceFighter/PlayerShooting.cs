using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // Use this for initialization

    public GameObject bulletPreFab;
    public float fireDelay = 0.25f;
    private float cooldownTimer = 0;

    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
      //  Debug.Log(Input.GetButton("Fire1"));

        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("Pew!");
            cooldownTimer = fireDelay;
            Instantiate(bulletPreFab, transform.position, transform.rotation);
        }
	}
}
