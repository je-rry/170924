using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaterDrop : MonoBehaviour {

	float delta = -0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Water is dropping y+=delta per frame
		float newYPosition = transform.position.y + delta;
		transform.position = new Vector3(0, newYPosition, -3f);

		// Repeat
		if (transform.position.y < -1.05){
			transform.position = new Vector3(0, 9.0f, -3f);
		}

	}
}
