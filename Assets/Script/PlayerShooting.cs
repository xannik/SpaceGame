using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // Use this for initialization
    public GameObject BulletPreFab;
    public float fireDelay = 0.25f;
    
   
    //public GameObject shootspawn;

    private float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
      //  Debug.Log(Input.GetButton("Fire1"));

        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            
            Shoot();
        }
      
	}
    void Shoot()
    {
        Debug.Log("Pew!");
        cooldownTimer = fireDelay;
        Instantiate(BulletPreFab, transform.position, transform.rotation);


    }
}
