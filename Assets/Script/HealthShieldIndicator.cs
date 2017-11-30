using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldIndicator : MonoBehaviour {

	private const float angleOffset = 45.0f; // 0.0f <-> 180.0f

	private float factor;

	private const int VALUE_MAX = 100;

	private Transform shieldLeft, shieldRight, healthLeft, healthRight;

	public GameObject shieldTextObject, healthTextObject;

	private HealthController healthScript;

	private Text shieldText, healthText;

	void Start () {

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		healthScript = player.GetComponent<HealthController> ();

		shieldLeft = transform.GetChild (0).GetChild (0);
		shieldRight = transform.GetChild (1).GetChild (0);
		healthLeft = transform.GetChild (0).GetChild (1);
		healthRight = transform.GetChild (1).GetChild (1);

		shieldText = shieldTextObject.GetComponent<Text> ();
		healthText = healthTextObject.GetComponent<Text> ();

		factor = (180.0f - angleOffset) / VALUE_MAX;
	}

	void Update () {
		
		updateShield ();
		updateHealth ();
	}

	private void updateShield () {
		
		int shield = healthScript.currentShield;

		shield = clamp (shield);

		shieldText.text = shield.ToString ();
		setShieldRotation (angleOffset + (VALUE_MAX - shield) * factor);
	}

	private void updateHealth () {
		
		int health = healthScript.currentHealth;

		health = clamp (health);

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

	private int clamp (int value) {

		return value > VALUE_MAX ? VALUE_MAX : value < 0 ? 0 : value;
	}
}