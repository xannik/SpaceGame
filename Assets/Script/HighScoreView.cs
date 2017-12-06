using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreView : MonoBehaviour {
	public Text names;
	public Text scores;

	private Vector3 shownPos, hiddenPos;

	private bool hidden;

	void Start () {
		shownPos = transform.localPosition;
		hiddenPos = new Vector3 (-1000.0f, 0.0f, 0.0f);
		hiddenPos += shownPos;
		hidden = false;

		swap ();
	}
	
	void Update () {
	}

//	public void show () {
//		if (hidden) {
//			transform.localPosition = hiddenPos;
//			hidden = false;
//		}
//	}
//
//	public void hide () {
//		if (!hidden) {
//			transform.localPosition = shownPos;
//			hidden = true;
//		}
//	}

	public void swap () {
		transform.localPosition = hidden ? shownPos : hiddenPos;
		hidden = !hidden;
	}
}
