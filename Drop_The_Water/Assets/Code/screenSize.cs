using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenSize : MonoBehaviour {

	void Awake () {
		Screen.SetResolution(1536, 2048, true);

		if(SceneManager.GetActiveScene().buildIndex == 15)
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}
