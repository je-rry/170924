using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialClicked : MonoBehaviour {

	public Toggle tutorialToggle;

	public bool tutorialOnOff;

	// Use this for initialization
	void Start () {
		string str = PlayerPrefs.GetString("tutorial", "true");
		tutorialOnOff = System.Convert.ToBoolean(str);

		if(tutorialOnOff){
			tutorialToggle.isOn = true;
		} else
			tutorialToggle.isOn = false;
	}
	
	// tutorial button changed event
	public void tutorialChanged() {
		tutorialOnOff = tutorialToggle.isOn;

		string str = System.Convert.ToString(tutorialOnOff);
		PlayerPrefs.SetString("tutorial", str);
		PlayerPrefs.Save();

		Debug.Log("tutorial : "+ str);
	}
}