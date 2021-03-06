﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthController : MonoBehaviour {

    private const int maxHealth = 100;
    private const int maxShield = 100;
    private float lastDamageTake = 0;
    private float nextShieldIncrease = 0;
    private int beginShield = 0;


    public int currentHealth = maxHealth;
    public int currentShield = maxShield;
    public GameObject ExplosionEffect = null;

    void Start()
    {
        beginShield = currentShield;
    }

    // Update is called once per frame
    void Update () {

        if ((Time.time - lastDamageTake) > 3 && beginShield > currentShield)
        {
            if (nextShieldIncrease < Time.time)
            {
                currentShield += 5;
                nextShieldIncrease = Time.time + 1;
            }
        }
	}

    public void TakeDamage(int amount)
    {
        lastDamageTake = Time.time;
        if (currentShield <= 0)
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

    private void saveScore(int score)
    {
        ArrayList array = new ArrayList();
        for (int i = 1; i < 8; i++)
        {
            array.Add(PlayerPrefs.GetInt("HighScorePoint" + i));
        }

        array.Add(score);
        array.Sort();
        array.Reverse();


        for (int i = 1; i < 8; i++)
        {
            Debug.Log((int)array[i - 1]);
            array.Add(PlayerPrefs.GetInt("HighScorePoint" + i));
            PlayerPrefs.SetInt("HighScorePoint" + i, (int)array[i - 1]);
        }
    }

    public void death()
    {
        if (this.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            saveScore(this.GetComponent<PlayerPoints>().getScore());
            SceneManager.LoadScene("Menu 3D");
        }
        else
        {
            if (ExplosionEffect)
            {
                GameObject explosion = Instantiate(ExplosionEffect, transform.position, transform.rotation);
                Destroy(explosion, 4.5f);
            }
            Destroy(gameObject);
        }
    }
}
