using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy_prefab = null;
    public GameObject player = null;

    private int wave_counter = 0;

	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (enemy_prefab == null)
            throw new System.Exception("Enemy prefab is missing");
    }
	
    void wavesSpawner()
    {
        if (Time.time > 10 && wave_counter == 0)
        {
            wave_counter++;
            for (int i = 0; i < 20; i++)
            {

            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (player == null)
            Debug.Log("Player == null");
        else
        {
            wavesSpawner();
        }
	}
}
