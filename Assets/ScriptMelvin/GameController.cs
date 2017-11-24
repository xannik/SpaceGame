using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy_prefab = null;
    public GameObject player = null;

    private int wave_counter = 0;

	// Use this for initialization
	void Start () {
        
    }
	 


	// Update is called once per frame
	void Update () {
        if (player == null)
            Debug.Log("Player == null");
        else
        {
                
        }
	}
}
