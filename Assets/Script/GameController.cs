using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    /*
    public GameObject[] asteroid;
    public int asteroidBeltSize;
    public int asteroidBeltHeight;
    public int nbAsteroid;

    // Create planets and asteroïds
    void createMap() {
        Vector2 posCircle;
        Vector3 pos;
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);

        for (int i = 0; i < nbAsteroid; i++)
        {
            posCircle = UnityEngine.Random.insideUnitCircle * asteroidBeltSize;
            pos.x = posCircle.x;
            pos.y = UnityEngine.Random.Range(-asteroidBeltHeight, asteroidBeltHeight);
            pos.z = posCircle.y;
            GameObject.Instantiate(asteroid[UnityEngine.Random.Range(0, asteroid.Length)], pos, UnityEngine.Random.rotationUniform);
        }
    }
    */
	// Use this for initialization
	void Start () {
        //createMap();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
