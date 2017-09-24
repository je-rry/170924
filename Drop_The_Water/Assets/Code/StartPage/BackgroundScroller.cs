using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public const float scrollSpeed = 1.2f;
	public const float offset = 0.1f;

	private Material thisMaterial;

	// Use this for initialization
	void Start () {
		thisMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {

		// Get material's current offset
		Vector2 newOffset = thisMaterial.mainTextureOffset;
		// Update offset by speed
		newOffset += new Vector2(offset * scrollSpeed * Time.deltaTime, 0);

		thisMaterial.mainTextureOffset = newOffset;
	}
}
