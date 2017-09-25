using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;

public class mainEvent : MonoBehaviour {

	public bool execute;
	public int puzzleLines;
	public string[] action = new string[2];
	public int[] number1 = new int[2];
	public int[] number2 = new int[2];

	public GameObject Water, RedWater;
	GameObject w_ater, red_water;

	bool correct, doMain;
	int userNum;


	// Use this for initialization
	void Start () {
		execute = false;
		correct = false;
		userNum = 0;
		doMain = true;
	}

	// Update is called once per frame
	void Update () {

		if(doMain) {
			// Get UseDLL values
			execute = UseDLL.instance.data.execute;
			puzzleLines = UseDLL.instance.data.puzzleLines;

			if(execute == true && puzzleLines == 2) {
				doMain = false;

				for(int i=0; i<2; i++){

					if(UseDLL.instance.data.puzzle[i].action != "none") 
						action[i] = UseDLL.instance.data.puzzle[i].action;
					else
						break;

					if(UseDLL.instance.data.puzzle[i].number1 != "none") {
						number1[i] = int.Parse(UseDLL.instance.data.puzzle[i].number1);
						userNum += 1;
					}
					else
						break;

					if(UseDLL.instance.data.puzzle[i].number2 != "none") {
						number2[i] = int.Parse(UseDLL.instance.data.puzzle[i].number2);
						userNum += 1;
					}
					else
						number2[i] = 0;
				}

				Debug.Log("excute : " + execute);
				Debug.Log("puzzleLines : " + puzzleLines);
				Debug.Log("action[0] : " + action[0]);
				Debug.Log("action[1] : " + action[1]);
				Debug.Log("number1[0] : " + number1[0]);
				Debug.Log("number1[1] : " + number1[1]);
				Debug.Log("number2[0] : " + number2[0]);
				Debug.Log("number2[1] : " + number2[1]);

				Debug.Log("Resouce.stage_add" + Resource.stage_add);
				Debug.Log("userNum : " + userNum);

				if(userNum == stageManager.instance.currentNum)
					MainAction(userNum);
			}
		}

	}



	void MainAction (int a) {

		int userAnswer;
		int num = stageManager.instance.firstCup;

		// calculation (2/2)
		for(int i=0; i<2; i++){

			// add calculation
			if(action[i] == "add") {

				// number1
				userAnswer = makeStage.gameNum[num] + number1[i];
				if(userAnswer == makeStage.answerNum[num]) {
					correct = true;
					stageManager.instance.answerStr.Add("add");
					num += 1;
				} else {
					correct = false;
					break;
				}

				// number2
				if(num < stageManager.instance.firstCup + a && number2[i] != 0) {
					userAnswer = makeStage.gameNum[num] + number2[i];

					if((makeStage.gameNum[num] + number2[i]) == makeStage.answerNum[num]) {
						correct = true;
						stageManager.instance.answerStr.Add("add");
						num += 1;
					} else {
						correct = false;
						break;
					}
				}
			} 

			
			// minus calculation
			if(action[i] == "minus") {

				// number1
				userAnswer = makeStage.gameNum[num] - number1[i];
				if(userAnswer == makeStage.answerNum[num]) {
					correct = true;
					stageManager.instance.answerStr.Add("minus");
					num += 1;
				} else {
					correct = false;
					break;
				}

				// number 2
				if(num < stageManager.instance.firstCup + a && number2[i] != 0) {
					userAnswer = makeStage.gameNum[num] - number2[i];

					if((makeStage.gameNum[num] - number2[i]) == makeStage.answerNum[num]) {
						correct = true;
						stageManager.instance.answerStr.Add("minus");
						num += 1;
					} else {
						correct = false;
						break;
					}
				}
			}
		}

		Debug.Log("correct  : "   + correct);

		// action
		if(correct) {
			num = stageManager.instance.firstCup;
			int lastCup = num + a;

			StartCoroutine(StageCups(lastCup, num));
		}
	}

	IEnumerator StageCups(int last, int num) {
		WaitForSeconds delay = new WaitForSeconds(0.2f);

		while(num < last) {
			stageManager.instance.cupIndex = num;
			yield return StartCoroutine(DropAction(num));

			if (num != (last-1)) {
				yield return delay;
				yield return StartCoroutine(MoveTap());
				yield return delay;
				stageManager.instance.finalDrop = false;
			} else
				stageManager.instance.stageFinish = true;

			num += 1;
		}
		Debug.Log("*****finalnum : " + stageManager.instance.cupIndex);
	}

	IEnumerator DropAction(int num) {
		
		if(stageManager.instance.answerStr[num] == "add")
			w_ater = (GameObject)Instantiate(Water, stageManager.instance.waterPos, Quaternion.identity);
		else if(stageManager.instance.answerStr[num] == "minus")
			red_water = (GameObject)Instantiate(RedWater, stageManager.instance.red_waterPos, Quaternion.identity);

		Debug.Log("answer: " + stageManager.instance.answerStr[num]);

		while (!stageManager.instance.finalDrop) 
			yield return null;
	}
		

	IEnumerator MoveTap () {
		stageManager.instance.tapPosX = stageManager.instance._tap.transform.position.x + 2.1f;
		float tapX = stageManager.instance._tap.transform.position.x;
		int tapResult = (int)(tapX * 10f);
		int defaultTap = (int)(stageManager.instance.tapPosX * 10f) + 1;
		WaitForSeconds delay = new WaitForSeconds(0.01f);

		while (tapResult < defaultTap) {
			tapResult += 1;
			Debug.Log("tapResult : " + tapResult);
			tapX = (float)tapResult / 10f;
			stageManager.instance._tap.transform.position = new Vector3 (tapX, 8.95f, 0);
			Debug.Log("tapX : " + tapX);
			yield return delay;
		}

		//Debug.Log("_tap.x" + stageManager.instance._tap.transform.position.x);
		//Debug.Log("tapPos : " + stageManager.instance.tapPosX);
	
		stageManager.instance.waterPos = new Vector3(tapX, 8f, 0);
		stageManager.instance.red_waterPos = new Vector3(tapX, 3.5f, 0);
	}
}