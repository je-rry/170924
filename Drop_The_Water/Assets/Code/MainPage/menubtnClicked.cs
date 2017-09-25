﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubtnClicked : MonoBehaviour {

	public GameObject main_menu, menu_bg, menu1, menu2, menu3, menu4, menu5;
	public GameObject hintBtn;
	public bool isBtn1;
	bool isMenu, isPause;


	// Use this for initialization
	void Start () {
		main_menu.SetActive (false);
		menu_bg.SetActive (false);
		menu1.SetActive (false);
		menu2.SetActive (false);
		menu3.SetActive (false);
		menu4.SetActive (false);
		menu5.SetActive (false);
		
		isMenu = false;
		isPause = false;
		isBtn1 = true;
	}
	
	
	void OnMouseDown() {
		
		if(isBtn1) {
			if(!isMenu) {

				hintBtn.GetComponent<hintbtnClicked>().isBtn2 = false;

				main_menu.SetActive (true);
				menu_bg.SetActive (true);
				menu1.SetActive (true);
				menu2.SetActive (true);
				menu3.SetActive (true);
				menu4.SetActive (true);
				menu5.SetActive (true);

				isMenu = true;

			
			} else {

				hintBtn.GetComponent<hintbtnClicked>().isBtn2 = true;

				main_menu.SetActive (false);
				menu_bg.SetActive (false);
				menu1.SetActive (false);
				menu2.SetActive (false);
				menu3.SetActive (false);
				menu4.SetActive (false);
				menu5.SetActive (false);

				isMenu = false;
			}
		
			if(!isPause) {
				Time.timeScale = 0;
				isPause = true;
			} else {
				Time.timeScale = 1;
				isPause = false;
			}
		}
	}
}
