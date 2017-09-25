using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

	public static Fade instance = null;

	void Awake () {

		if(!instance) {
           instance = this;
		   DontDestroyOnLoad(this);
    	} else
            Destroy(this);

		Screen.SetResolution(1536, 2048, true);

		if(SceneManager.GetActiveScene().buildIndex == 15)
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public IEnumerator FadeOut(SpriteRenderer s, float fl) {
		Color color = s.color;

		while(color.a > fl) {
			color.a -= 0.05f;
			s.color = color;
			yield return null;
		}
	}

	public IEnumerator FadeIn(SpriteRenderer s, float fl) {
		Color color = s.color;

		while(color.a < fl) {
			color.a += 0.05f;
			s.color = color;
			yield return null;
		}
	}
}
