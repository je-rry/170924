using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toHelpPage : toNextPage {

	private int helpPrevious;
	
	// go to next scene (in help page)
	public override void GotoNext() {
		helpPrevious = SceneManager.GetActiveScene().buildIndex;
		int nextScene = helpPrevious + 1;

		if(nextScene<15){
			SceneManager.LoadScene(nextScene);
		}

		Debug.Log("previous : " + previousScene + "	helpPrevious :" + helpPrevious);
	}

	// go to specific scene (in help page)
	public override void GotoScene(int i) {
		helpPrevious = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(i);
	}

	// go to previous scene (in help page)
	public override void GoBack() {
		SceneManager.LoadScene(helpPrevious);
	}

	// go to setting scene (out from help page)
	public void GotoSetting() {
		base.GoBack();
		previousScene = settingBack;
	}
}
