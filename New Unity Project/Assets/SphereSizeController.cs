using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSizeController : MonoBehaviour
{
	public int index;
	public int angle;
	public float scaleDivide;
	private bool doRotate = false;

	void Start ()
	{
		makeChildren ();
	}

	void makeChildren ()
	{
		index--;
		if (index > 0) {
			transform.rotation *= Quaternion.Euler (0, angle, 0);
			var instance = Instantiate (gameObject);
			instance.transform.localScale *= scaleDivide;
			instance.transform.Translate (new Vector3 (((transform.localScale.x / 2) + (instance.transform.localScale.x / 2)), 0, 0));
			transform.rotation *= Quaternion.Euler (0, -angle * 2, 0);
			var instance2 = Instantiate (gameObject);
			instance2.transform.localScale *= scaleDivide;
			instance2.transform.Translate (new Vector3 (((transform.localScale.x / 2) + (instance.transform.localScale.x / 2)), 0, 0));
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) {
			doRotate = !doRotate;
		}
		if (doRotate) {
			transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
		}
	}
}