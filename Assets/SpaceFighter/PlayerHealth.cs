using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth: MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth = 0;
    public int startingShield = 80;
    public int currentShield = 0;
    public float flashSpeed = 5f;
    public Color flashcolor = new Color(1f, 0f, 0f, 0.1f);

    MelvinPlayerController melvinPlayer;
    bool isDead;
    bool damaged;

    void Awake()
    {
        melvinPlayer = GetComponent<MelvinPlayerController>();

    }
    void Update()
    {
        if (damaged)
        {
            Debug.Log("you take damage");
        }

    }
    public void TakeDamage(int amount)
    {
        damaged = true;

        if (currentShield <= 0)
        {
            currentHealth -= amount;
        }
        else
        {
            currentShield -= amount;
        }
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        melvinPlayer.enabled = false;
    }
}
