using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour {

    // Use this for initialization
    public GameObject bulletPreFab1;
    public GameObject bulletPreFab2;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public float fireDelay = 0.25f;
    public int speed = 100;
    private float cooldownTimer1 = 10;
    private float cooldownTimer2 = 5;
    private float timer = 5;
    Vector3 direction;


    //public GameObject shootspawn;

    private float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
         cooldownTimer1 -= Time.deltaTime;
         cooldownTimer2 -= Time.deltaTime;
        //  Debug.Log(Input.GetButton("Fire1"));

        if (Input.GetKeyDown(KeyCode.Alpha1) && cooldownTimer1 <= 0)
        {
            // Debug.Log("Pew!");
            cooldownTimer1 = 10;

            
            Shoot(bulletPreFab1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && cooldownTimer2 <= 0)
        {
            cooldownTimer2 = 5;
            
            Shoot(bulletPreFab2);
        }

    }
    void Shoot(GameObject prefab)
    {
        cooldownTimer = fireDelay;
        GameObject bullet1 = Instantiate(prefab, bulletSpawn1.position, bulletSpawn1.rotation);
        GameObject bullet2 = Instantiate(prefab, bulletSpawn2.position, bulletSpawn2.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * speed;
        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * speed;

        Destroy(bullet1, timer);
    }
}
