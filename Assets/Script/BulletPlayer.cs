using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {
    
    public int damagePerShot = 5;
    GameObject player;
    public GameObject CollisionEffect = null;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        HealthController health = hit.GetComponent<HealthController>();
        //Debug.Log("it's a hit " + hit);

        if (hit.gameObject == player.gameObject)
        {
            //Debug.Log("Ignoring physics");
            Collider[] playerColliders = player.GetComponents<Collider>();

            Physics.IgnoreCollision(hit.GetComponent<CapsuleCollider>(), playerColliders[0], false);
            Physics.IgnoreCollision(hit.GetComponent<CapsuleCollider>(), playerColliders[1], false);
        }
        else if (health != null)
        {
            Debug.Log("Shoot " + hit);
            Debug.Log("Effect at hit: !" +  hit.transform.position + "  transform = " + transform.position);

            if (CollisionEffect)
            {
                GameObject effect = Instantiate(CollisionEffect, transform.position, transform.rotation);
                Destroy(effect, 4.5f);
            }
            health.TakeDamage(damagePerShot);
            Destroy(gameObject);
        }
    }
   
}
