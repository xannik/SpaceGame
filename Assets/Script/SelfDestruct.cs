using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public float timer = 5f;
    public int damagePerShot = 20;
    // Use this for initialization


    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
	}
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        HealthController health = hit.GetComponent<HealthController>();

        if(health != null)
        {
            health.TakeDamage(damagePerShot);
            Destroy(gameObject);
        }
        else
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
