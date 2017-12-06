using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
	public Text scoreText;
    public GameObject player = null;

	void Start () {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		scoreText.text = "Score: " + player.GetComponent<PlayerPoints>().getScore();
	}
}
