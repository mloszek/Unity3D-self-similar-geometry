using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSizeController : MonoBehaviour
{
	public int index;
	public int angle;
	public float scaleDivide;
	public int scaleIndex = 0;
	public bool wasAlready;

	private bool doRotate = false;
	private GameObject child1;
	private GameObject child2;

	void Start ()
	{
		if (wasAlready){
			wasAlready = false;
			makeChildren (index);
		}
	}

	public void makeChildren (int index)
	{
		index--;
		if (index > 0) {
			
			transform.rotation *= Quaternion.Euler (angle, 0, 0);

			var instance = Instantiate (gameObject);
			instance.transform.localScale *= scaleDivide;
			instance.transform.Translate (new Vector3(0, ((gameObject.transform.lossyScale.x + instance.transform.lossyScale.x) / 2), 0));


			transform.rotation *= Quaternion.Euler (-angle * 2, 0 , 0);

			var instance2 = Instantiate (gameObject);
			instance2.transform.localScale *= scaleDivide;
			instance2.transform.Translate (new Vector3(0, ((gameObject.transform.lossyScale.x + instance2.transform.lossyScale.x) / 2), 0));
//			instance.transform.parent = gameObject.transform;
//			instance2.transform.parent = gameObject.transform;

			transform.rotation *= Quaternion.Euler (angle, 0, 0);
//
//			Vector3 position1 = transform.TransformPoint (instance.transform.position);
//			Vector3 position2 = transform.TransformPoint (instance2.transform.position);
//
			instance.transform.parent = gameObject.transform;
			instance2.transform.parent = gameObject.transform;

			instance.GetComponent<SphereSizeController>().makeChildren (index);
			instance2.GetComponent<SphereSizeController>().makeChildren (index);
//			instance.transform.position = position1;
//			instance2.transform.position = position2;
		}
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) {
			doRotate = !doRotate;
		}
		if (doRotate) {
			//transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
			transform.RotateAround(transform.position, transform.up, 20 * Time.deltaTime);
		}
	}
}