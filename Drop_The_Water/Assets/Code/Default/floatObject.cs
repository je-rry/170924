using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatObject : MonoBehaviour {

	public float delta;

	Vector3 beforePosition;
	// Use this for initialization
	void Start () {
		// Object's original position
		beforePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Object move y+=delta per frame
		float newYPosition = transform.position.y + delta;
		transform.position = new Vector3(beforePosition.x, newYPosition, 0);

		// Repeat
		if (transform.position.y < beforePosition.y || transform.position.y > (beforePosition.y + 0.2f))
			delta = -delta;
	}
}
