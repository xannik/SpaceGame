using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public const int maxHealth = 100;
    public const int maxShield = 100;
    public int currentHealth = maxHealth;
    public int currentShield = maxShield;
    

    // Update is called once per frame
    void Update () {
		    
	}
    public void TakeDamage(int amount)
    {
        //Debug.Log("HIIIIIITITITITITITITITIT");
        if (currentShield < 0)
        {
            currentHealth -= amount;
            if(currentHealth <= 0)
            {
                death();
            }
        }
        else
        {
            currentShield -= amount;
        }
    }
    public void death()
    {
        if (this.tag == "Player")
            SceneManager.LoadScene("Menu 3D");
        else
            Destroy(gameObject);
        //Debug.Log("dead");
    }
}
