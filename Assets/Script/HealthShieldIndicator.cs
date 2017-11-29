using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldIndicator : MonoBehaviour {

	private int health;
	private int shield;

	private const float angleOffset = 45.0f; // 0.0f <-> 180.0f

	private float factor;

	private const int VALUE_MAX = 100;

//	private float t = 0.0f;

	private Transform shieldLeft, shieldRight, healthLeft, healthRight;

	public GameObject shieldTextObject, healthTextObject;

	private Text shieldText, healthText;

	// Use this for initialization
	void Start () {
		health = shield = VALUE_MAX;

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

//		shield = (int)(50 * (1 + Mathf.Cos (t)));
//		health = (int)(50 * (1 + Mathf.Cos (t+Mathf.PI)));
//		t += 0.05f;

		if (shield > 0) {
			shield--;
		} else if (health > 0) {
			health--;
		} else {
			shield = health = VALUE_MAX;
		}
//
		updateShield ();
		updateHealth ();
	}

	private void updateShield () {
		shieldText.text = shield.ToString ();
		setShieldRotation (angleOffset + (VALUE_MAX - shield) * factor);
	}

	private void updateHealth () {
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
