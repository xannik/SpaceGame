using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

//[ExecuteInEditMode]
public class RadarBackground : MonoBehaviour {

	private GameObject player;

//	private float x;

	// Use this for initialization
	void Start () {
		
		if (player == null) {

			player = GameObject.FindGameObjectWithTag("Player");
		}

//		var mesh = (transform.GetComponent("MeshFilter") as MeshFilter).mesh;
//		mesh.uv = mesh.uv.Select(o => new Vector2(1 - o.x, o.y)).ToArray();
//		mesh.triangles = mesh.triangles.Reverse().ToArray();
//		mesh.normals = mesh.normals.Select(o => -o).ToArray();
//
//		x = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {

		transform.localRotation = player.transform.localRotation;

//		Vector3 pr = player.transform.rotation.eulerAngles;

//		Vector3 tr = transform.localRotation.eulerAngles;

//		tr.z = tr.z - pr.z;

//		Quaternion q = transform.rotation;

//		q.eulerAngles = new Vector3 (x, 0, 0);

//		q.eulerAngles.Set (x, 0, 0);


//		x = -player.transform.rotation.eulerAngles.z;

//		transform.rotation = Quaternion.AngleAxis(-player.transform.localRotation.eulerAngles.x, transform.up);

//		transform.rotation = Quaternion.AngleAxis(-player.transform.localRotation.eulerAngles.y, transform.right);

//		transform.rotation = Quaternion.AngleAxis(-player.transform.rotation.eulerAngles.z, Vector3.forward);



//		transform.Rotate (new Vector3 (x, y, z)); // = new Quaternion (x, 0, 0, 0);


//		x += 1.0f;

//		Quaternion p = player.transform.rotation;
//
//		Quaternion s = transform.rotation;
//

//

//		Vector3 pr = p.eulerAngles;
//
//		Vector3 sr = s.eulerAngles;
//
//		sr = -pr;

//		transform.rotation = Quaternion.FromToRotation (-sr, pr);

//		Quaternion p = player.transform.rotation;
//
//		Vector3 pr = p.eulerAngles;
//
//		transform.rotation.eulerAngles.Set ();

//		transform.localRotation = Quaternion.FromToRotation (transform.rotation.eulerAngles, player.transform.rotation.eulerAngles);

//		transform.Rotate(new Vector3(1.0f,0,0));
	}
}
