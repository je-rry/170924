using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using ObjectHierachy;
using System.IO;

public class makeStage : MonoBehaviour {
	public delegate void Clear ();

	public GameObject cup, cupAnswer, parentCup, answer_bg, parentAnswer;

	public static int[] answerNum;
	public static int[] gameNum;

	// Dynamic allocation Game object
	public static List<GameObject> answerCup = new List<GameObject>();
	public static List<GameObject> gameCup = new List<GameObject>();

	public static Clear clearEvent;

	Vector3 answerPos;
	Vector3 gamePos = new Vector3(0, 4f, 0);


	// Use this for initialization
	void Start () {

		loadStage (Resource.stage, 1, 0, 0);

		stageManager.instance.stageMod = gameNum.Length % 4;

		if(stageManager.instance.stageMod != 0) {
			stageManager.instance.entireStage = (gameNum.Length/4) + 1;
		}
		else {
			stageManager.instance.entireStage = gameNum.Length;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Create Stage
	void loadStage(int stage, int stageNum, int stageMod, int firstCup) {
		Debug.Log (Resource.stage);

		// Read stage game data
		TextAsset data = Resources.Load ("StageText/text" + stage, typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		// Create game cup & answer cup
		while((line = str.ReadLine()) != null) {
			if(line.Equals("cup")){
				line = str.ReadLine();
				string[] o = line.Split (new char[]{ ' ' });
				Debug.Log (o [0]);

				gameNum = new int[o.Length];

				for(int i=0; i<o.Length; i++) {
					gameNum[i] = int.Parse (o [i]);
				}

				createCup (gameNum);
			}
			else if(line.Equals("answer")) {
				line = str.ReadLine();
				string[] o = line.Split (new char[]{ ' ' });

				answerNum = new int[o.Length];
				
				for(int i=0; i<o.Length; i++) {
					answerNum[i] = int.Parse (o [i]);
				}

				createAnswer(stageNum, stageMod, firstCup);
			}
		}
	}


	// create game cup
	public void createCup(int[] a){
		for(int i=0; i <a.Length; i++){
			GameObject _cup = Instantiate(cup, gamePos, Quaternion.identity) as GameObject;
			gameCup.Add(_cup);
			_cup.transform.parent = parentCup.transform;
			gameCup[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("cup/cup_" + gameNum[i]);
			StartCoroutine(Fade.instance.FadeIn(gameCup[i].GetComponent<SpriteRenderer>(),1.0f));
			gamePos.x += 2.1f;
		}
	}


	// create answer cup	
	public void createAnswer(int stageNum, int stageMod, int firstCup){
		int i = 0;
		int rest = 0;
		answerPos = new Vector3(-6.3f,8.5f,0);
		float bgPosX = answer_bg.transform.position.x;
		float bgScale = answer_bg.transform.localScale.x;

		// game cup => 4/3 or 4/4
		// game cup < 4
		if(stageMod != 0 && stageNum == stageManager.instance.entireStage) {
			
			rest = 4 - stageMod;
			bgPosX -= (0.6f * (float)rest);
			bgScale -= (0.22f * (float)rest); 

			answer_bg.transform.position = new Vector3(bgPosX, 8.5f, 0);
			answer_bg.transform.localScale = new Vector3(bgScale, 1, 1);

			for(int j = firstCup; j< firstCup+stageMod; j++) {
				GameObject _cupAnswer = Instantiate(cupAnswer, answerPos, Quaternion.identity) as GameObject;
				answerCup.Add(_cupAnswer);
				_cupAnswer.transform.parent = parentAnswer.transform;
				answerCup[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("cup/colorCup_" + answerNum[j]);
				answerPos.x += 1.2f;
				i++;
			}
		} 
		// game cup = 4
		else {
			for(int j = firstCup; j<firstCup+4; j++){
				GameObject _cupAnswer = Instantiate(cupAnswer, answerPos, Quaternion.identity) as GameObject;
				answerCup.Add(_cupAnswer);
				_cupAnswer.transform.parent = parentAnswer.transform;
				answerCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_" + answerNum[j]);
				answerPos.x += 1.2f;
				i++;
			}
		}

		stageManager.instance.currentNum = i;
	}
}