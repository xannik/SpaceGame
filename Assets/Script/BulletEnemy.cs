using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public int damagePerShot = 5;
    public GameObject CollisionEffect = null;
    
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        HealthController health = hit.GetComponent<HealthController>();
        //Debug.Log("it's a hit " + hit);

        if (hit.tag == "Enemy") 
        {
            //Debug.Log("Ignoring physics");
            Collider[] playerColliders = hit.GetComponents<Collider>();

            Physics.IgnoreCollision(hit.GetComponent<CapsuleCollider>(), playerColliders[0], false);
            Physics.IgnoreCollision(hit.GetComponent<CapsuleCollider>(), playerColliders[1], false);
        }
        else if (health != null)
        {
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
