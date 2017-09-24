using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toNextPage : MonoBehaviour {

    public static int previousScene = 0;
	public static int settingBack = 0;

	// go to next scene
	public virtual void GotoNext() {
		previousScene = SceneManager.GetActiveScene().buildIndex;
		int nextScene = previousScene + 1;

		if(nextScene<18){
			SceneManager.LoadScene(nextScene);
		}

		Debug.Log("previous :"+previousScene+" && nextScene : "+nextScene);
	}

	// go to previous scene
	public virtual void GoBack() {
		Debug.Log(previousScene);
		SceneManager.LoadScene(previousScene);
	}
	
	// go to specific scene
	public virtual void GotoScene(int i) {
		previousScene = SceneManager.GetActiveScene().buildIndex;
		Debug.Log(previousScene);
		SceneManager.LoadScene(i);

		if (i == 1 || i == 16)
			settingBack = previousScene;
	}

	// go to tutorial by tutorial on/off
	public void GotoTutorial() {
		previousScene = SceneManager.GetActiveScene().buildIndex;

		string str = PlayerPrefs.GetString("tutorial", "true");
		bool isActive = System.Convert.ToBoolean(str);

		if(isActive)
			SceneManager.LoadScene(2);
		else
			SceneManager.LoadScene(4);
	}
}