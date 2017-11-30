using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    // Use this for initialization
    public GameObject BulletPreFab;
    public Transform bulletSpawn;
    public float fireDelay = 0.25f;
    public int speed = 100;
    public float timer = 3f;


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
       cooldownTimer = fireDelay;
       GameObject bullet = Instantiate(BulletPreFab, bulletSpawn.position, bulletSpawn.rotation);
       bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

        Destroy(bullet, timer);
    }
}
