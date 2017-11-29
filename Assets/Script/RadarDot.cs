using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDot : MonoBehaviour {
	
	private const float scale = 0.001f;

	public GameObject player;
	public GameObject enemy;

	private float radar_radius;

	void Start () {
		if (player == null) {
			
			player = GameObject.FindGameObjectWithTag("Player");
		}

		radar_radius = 0.375f * 200; // GetComponent<RectTransform> ().rect.height;
	}
	
	void Update () {
		if (enemy != null) {

			Vector3 direction = enemy.transform.position - player.transform.position;

			float rotation = Vector3.SignedAngle (player.transform.forward,
				                 direction,
				                 Vector3.Cross (player.transform.forward, direction));

			float angle = Vector3.SignedAngle (player.transform.right, 
				              Vector3.ProjectOnPlane (direction, player.transform.forward), 
				              player.transform.forward);

			float factor = radar_radius * rotation / 180.0f;

			float xPos = factor * Mathf.Cos (Mathf.Deg2Rad * angle);
			float yPos = factor * Mathf.Sin (Mathf.Deg2Rad * angle);

			float opacity = 1.0f / (1.0f + scale * direction.magnitude);

			setOpacity (opacity);

			transform.localPosition = new Vector2 (xPos, yPos);

		} else {

			setOpacity (0.0f);
		}
	}

	void setOpacity(float opacity) {
		
		Image i = GetComponentInChildren<Image> ();

		i.color = new Color (1.0f, 1.0f, 1.0f, opacity);
	}

}
