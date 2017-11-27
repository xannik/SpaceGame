using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarDot : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;

	private float radar_radius;

	void Start () {
		radar_radius = 0.375f * 200; 
//		q = 0.375f * GetComponent<RectTransform> ().rect.height;
	}
	
	void Update () {
		Vector3 direction = enemy.transform.position - player.transform.position;


		float rotation = Vector3.SignedAngle (player.transform.forward,
			direction,
			Vector3.Cross(player.transform.forward,direction));

		float angle = Vector3.SignedAngle (player.transform.right, 
			Vector3.ProjectOnPlane (direction, player.transform.forward), 
			player.transform.forward);

		float x = Mathf.Cos (Mathf.Deg2Rad * angle);
		float y = Mathf.Sin (Mathf.Deg2Rad * angle);

		float factor = radar_radius * rotation / 180.0f;

		x *= factor;
		y *= factor;

		float closeness = 1000.0f / (1000.0f + direction.magnitude);

		Image i = GetComponentInChildren<Image> ();

		i.color = new Color (1.0f, 1.0f, 1.0f, closeness);

		transform.localPosition = new Vector2 (x, y);
	}
}
