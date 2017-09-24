using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using UnityEngine.SceneManagement;


public class toSongPlay : MonoBehaviour {

	int i;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{

	}


	void OnMouseUp() {

		Resource.stage = (SelectStage.stageNum+1)*100;

		SceneManager.LoadScene (5);
		Debug.Log ("stage" + Resource.stage);
}
}