using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour {

	public Vector3 waterPos;
	public Vector3 red_waterPos;
	public float tapPosX;

	public bool stageFinish, doStage;
	public bool drop, finalDrop, mainStart;

	public int firstCup = 0;
	public int cupIndex = 0;
	public int currentNum = 0;
	public int entireStage, stageMod;
	public  List<string> answerStr = new List<string>();

	public makeStage makeControls;
	public GameObject mainAction, _tap, answerFade;
	GameObject act_main;


	//Singleton
	public static stageManager instance = null;

	void Awake() {
		if(!instance) {
           instance = this;
       } else
            Destroy(this);
	}

	// Use this for initialization
	void Start () {
		waterPos = new Vector3(0, 8f, 0);
		red_waterPos = new Vector3(0, 3.5f,0);
		tapPosX = 0;

		_tap.transform.position = new Vector3(tapPosX, 8.95f, 0);

		stageFinish = false;

		//stage first cup's index
		firstCup = cupIndex = Resource.stage_add * 4 - 4;

		drop = false;
		finalDrop = false;

		doStage = true;
		mainStart = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(doStage){

			if(!stageFinish) {
				if(!mainStart) {
					act_main = (GameObject)Instantiate(mainAction, Vector3.zero, Quaternion.identity);
					mainStart = true;
				}
			} else {
				doStage = false;
				Destroy(act_main);
			
				Resource.stage_add += 1;

				StartCoroutine(NextStage(Resource.stage_add));
			}
		}
	
	} 



	IEnumerator NextStage(int st) {
		WaitForSeconds delay = new WaitForSeconds(0.1f);
		float movetap;
		float movecup;

		yield return new WaitForSeconds(1f);
		yield return StartCoroutine(Fade.instance.FadeIn(answerFade.GetComponent<SpriteRenderer>(),1f));
		for(int i=0; i < currentNum; i++) {
				Destroy(makeStage.answerCup[i]);
		}

		makeStage.answerCup.Clear();

		if(st <= entireStage) {

			Resource.stage += 1;
			firstCup = cupIndex = Resource.stage_add * 4 - 4;
			currentNum = 3;
			makeControls.createAnswer(st, stageMod, firstCup);
			yield return StartCoroutine(Fade.instance.FadeOut(answerFade.GetComponent<SpriteRenderer>(),0f));

			movetap = (4-currentNum) * 2.1f;
			movecup = currentNum * 2.1f;

			yield return delay;
			yield return StartCoroutine(BackTap(movetap));
			yield return delay;
			yield return StartCoroutine(MoveCup(movecup));
			yield return delay;

			stageFinish = false;
			finalDrop = false;
			drop = false;
			doStage = true;
			mainStart = false;

		} else {

			Destroy(makeControls.answer_bg.gameObject);

			movetap = 0;
			movecup = 25f;

			yield return delay;
			yield return StartCoroutine(BackTap(movetap));
			yield return delay;
			yield return StartCoroutine(MoveCup(movecup));
			yield return delay;

			makeControls.parentCup.transform.position = new Vector3 (10f, -12.2f, 0);
			movecup = 6.3f;
			yield return delay;
			yield return StartCoroutine(MoveCup(movecup));
			yield return new WaitForSeconds(2f);

			SceneManager.LoadScene (16);
		}
	}

	IEnumerator BackTap(float m) {
		float tapX = stageManager.instance._tap.transform.position.x;
		int tapResult = (int)(tapX * 10f);
		int defaultTap = (int)(m * 10f) + 1;
		WaitForSeconds delay = new WaitForSeconds(0.0001f);

		while (tapResult > defaultTap) {
			tapResult -= 1;
			tapX = (float)tapResult / 10f;
			stageManager.instance._tap.transform.position = new Vector3 (tapX, 8.95f, 0);
			yield return delay;
		}
		
		stageManager.instance.waterPos = new Vector3(tapX, 8f, 0);
		stageManager.instance.red_waterPos = new Vector3(tapX, 3.5f, 0);
	}

	IEnumerator MoveCup(float m) {
		float cupX = makeControls.parentCup.transform.position.x;
		float cupY = makeControls.parentCup.transform.position.y;
		int cupResult = (int)(cupX * 10f);
		int defaultCup = -((int)(m * 10f) + 1);
		WaitForSeconds delay = new WaitForSeconds(0.0001f);

		while (cupResult > defaultCup) {
			cupResult -= 2;
			cupX = (float)cupResult / 10f;
			makeControls.parentCup.transform.position = new Vector3(cupX, cupY, 0);
			yield return delay;
		}
	}
}
