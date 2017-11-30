#define HEALTH_SCRIPT_EXISTS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldIndicator : MonoBehaviour {

	private const float angleOffset = 45.0f; // 0.0f <-> 180.0f

	private float factor;

	private const int VALUE_MAX = 100;

	private Transform shieldLeft, shieldRight, healthLeft, healthRight;

	public GameObject shieldTextObject, healthTextObject, player;

	private Component healthScript;

	private Text shieldText, healthText;

	// Use this for initialization
	void Start () {

		#if HEALTH_SCRIPT_EXISTS
		player = GameObject.FindGameObjectWithTag("Player");
//		healthScript = player.GetComponent<HealthController> ();
		#endif

		shieldLeft = transform.GetChild (0).GetChild (0);
		shieldRight = transform.GetChild (1).GetChild (0);
		healthLeft = transform.GetChild (0).GetChild (1);
		healthRight = transform.GetChild (1).GetChild (1);

		shieldText = shieldTextObject.GetComponent<Text> ();
		healthText = healthTextObject.GetComponent<Text> ();

		factor = (180.0f - angleOffset) / VALUE_MAX;
	}

	// Update is called once per frame
	void Update () {
		updateShield ();
		updateHealth ();
	}

	private void updateShield () {
		#if HEALTH_SCRIPT_EXISTS
		int shield = player.GetComponent<HealthController>().currentShield;
		#else
		int shield = 25;
		#endif

		shieldText.text = shield.ToString ();
		setShieldRotation (angleOffset + (VALUE_MAX - shield) * factor);
	}

	private void updateHealth () {
		#if HEALTH_SCRIPT_EXISTS
		int health = player.GetComponent<HealthController>().currentHealth;
		#else
		int health = 75;
		#endif

		healthText.text = health.ToString ();
		setHealthRotation (angleOffset + (VALUE_MAX - health) * factor);
	}

	private void setShieldRotation (float angle) {

		shieldLeft.rotation = Quaternion.AngleAxis(-angle, shieldLeft.forward);
		shieldRight.rotation = Quaternion.AngleAxis(angle, shieldRight.forward);

	}

	private void setHealthRotation (float angle) {

		healthLeft.rotation = Quaternion.AngleAxis(-angle, healthLeft.forward);
		healthRight.rotation = Quaternion.AngleAxis(angle, healthRight.forward);
	}
}
