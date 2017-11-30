using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public int damagePerShot = 20;
    GameObject player;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Enemy");
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
        if (health != null)
        {

            if (health.currentHealth == 0)
            {
                Destroy(other.gameObject);
            }
            else
            {
                health.TakeDamage(damagePerShot);
                Destroy(gameObject);
            }


        }
    }
}
