using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int curentHealth;
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;
    EnemyAI enemy;
    bool isDead;
   
	// Use this for initialization
	void Awake () {
        enemy.GetComponent<EnemyAI>();
        capsuleCollider = GetComponent<CapsuleCollider>();    	
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}
    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        curentHealth -= amount;
        if (curentHealth <= 0)
        {
            Death();
        }
    }
    public void Death() {
        isDead = true;
        capsuleCollider.isTrigger = true;
        enemy.enabled = false;
    }
}
