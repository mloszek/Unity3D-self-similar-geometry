using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public GameObject singleElement;
	public float scaleDivide;
	public int iterations;
	public int angle;

	void Start () {
		GenerateObjects ();
	}

	public void GenerateObjects () {

		GameObject el1 = Instantiate (singleElement);
		el1.transform.position = Vector3.one;

		GameObject el2 = Instantiate (singleElement);
		el2.transform.localScale = el1.transform.localScale * scaleDivide;
		el2.transform.position = el1.transform.position + (new Vector3(0, ((el1.transform.lossyScale.x + el2.transform.lossyScale.x) / 2), 0));

		GameObject el3 = Instantiate (singleElement);
		el3.transform.localScale = el1.transform.localScale * scaleDivide;
		el3.transform.position = el1.transform.position - (new Vector3(0, ((el1.transform.lossyScale.x + el3.transform.lossyScale.x) / 2), 0));

		el2.transform.parent = el1.transform;
		el3.transform.parent = el1.transform;
	}
}
