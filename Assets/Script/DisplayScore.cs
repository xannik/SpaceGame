using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	public int score;
	public Text scoreText;

	void Start () {
		score = 0;
	}
	
	void Update () {
		scoreText.text = "Score: " + score;

		score += 999;
	}
}
