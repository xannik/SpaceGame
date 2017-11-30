using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class RadarBackground : MonoBehaviour {

	private GameObject player;

	private const float t = 1.0f;
	private const float r = 1.5f;

	// Use this for initialization
	void Start () {
		
		if (player == null) {

			player = GameObject.FindGameObjectWithTag("Player");
		}


		Mesh mesh = transform.GetComponent<MeshFilter> ().sharedMesh;
//		var mesh = (transform.GetComponent("MeshFilter") as MeshFilter).mesh; // original line, creates runtime error

		mesh.uv = mesh.uv.Select(o => new Vector2(1 - o.x, o.y)).ToArray();
		mesh.triangles = mesh.triangles.Reverse().ToArray();
		mesh.normals = mesh.normals.Select(o => -o).ToArray();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		transform.rotation = player.transform.rotation;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Rotate(new Vector3(0, 0, -1), r, Space.World);
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Rotate(new Vector3(0, 0, 1), r, Space.World);
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			transform.Rotate(new Vector3(-1, 0, 0), t, Space.World);
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			transform.Rotate(new Vector3(1, 0, 0), t, Space.World);
		
	}
}
