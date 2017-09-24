using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using UnityEngine.SceneManagement;



public class toMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Resource.stage_add = 1;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{

	}

	void OnMouseUp() {

		//매번 다른 stage를 불러
		Resource.stage += Resource.stage_add;
		//Resource.stage_add++;
		/*if (Resource.stage_add == 5) {
			Resource.stage_add = 1;
		}
		else{
			Resource.stage_add++;
		}*/

		SceneManager.LoadScene (15);

		Debug.Log ("stage" + Resource.stage);
	}
}