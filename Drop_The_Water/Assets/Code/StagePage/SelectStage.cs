using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour {

	public int totalStage;
	public GameObject[] select;
	public GameObject[] mapStage;
	public SpriteRenderer[] spr;
	public Transform tr;

	public static int stageNum;
	public Vector3 rotatePivot;

	public Swipe swipeControls;
	

	// Use this for initialization
	void Start () {

		totalStage = select.Length;
		stageNum = 0;
		changeSelect();
		makeMap();
	}
	
	// Update is called once per frame
	void Update () {
		if (swipeControls.SwipeLeft)
			rightClick();
		if (swipeControls.SwipeRight)
			leftClick();
	}

	// change select button
	public void changeSelect() {
		for(int i = 0; i < totalStage; i++)
		{
			if(i == stageNum)
				select[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("map/select");
			else
				select[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("map/unselect");
		}
	}

	// first setting stage map
	public void makeMap() {
		float zrotateLeft = 6f;
		float zrotateRight = -6f;

		for(int i=0; i<totalStage; i++){
			
			tr = mapStage[i].GetComponent<Transform>();

			if(i == stageNum)
				tr.position = new Vector3(0, 1.62f, 0);
			else if (i < stageNum){
				tr.RotateAround(rotatePivot, Vector3.forward, zrotateLeft);
				zrotateLeft += 6f;
			} else {
				tr.RotateAround(rotatePivot, Vector3.forward, zrotateRight);
				zrotateRight += -6f;
			}
		}
	}

	// left button onclick event
	public void leftClick() {
		int previousStage = stageNum;
		
		if((previousStage-1) > -1) {
			stageNum--;
			changeSelect();
			for(int i=0; i<totalStage; i++){
				spr = mapStage[i].GetComponentsInChildren<SpriteRenderer>();

				if(i == stageNum){

					for(int j=0; j< spr.Length; j++)
						StartCoroutine(StageFadeIn(spr[j]));

					StopCoroutine("StageFadeIn");
					StartCoroutine(StageBigger(mapStage[i]));
					StartCoroutine(StageRotateRight(mapStage[i]));

				} else if (i == previousStage) {

					for(int k=0; k < spr.Length; k++)
						StartCoroutine(StageFadeOut(spr[k]));
			
					StopCoroutine("StageFadeOut");
					StartCoroutine(StageSmaller(mapStage[i]));
					StartCoroutine(StageRotateRight(mapStage[i]));

				} else
					StartCoroutine(StageRotateRight(mapStage[i]));
			}

			StopCoroutine("StageSmaller");
			StopCoroutine("StageBigger");
			StopCoroutine("StageRotateRight");
		}
	}

	// right button onclick event
	public void rightClick() {
		int previousStage = stageNum;
		if((previousStage+1) < totalStage) {
			stageNum++;
			changeSelect();

			for(int i=0; i<totalStage; i++){
				spr = mapStage[i].GetComponentsInChildren<SpriteRenderer>();
				
				if(i == stageNum){
					for(int j=0; j< spr.Length; j++)
						StartCoroutine(StageFadeIn(spr[j]));

					StopCoroutine("StageFadeIn");
					StartCoroutine(StageBigger(mapStage[i]));
					StartCoroutine(StageRotateLeft(mapStage[i]));

				} else if (i == previousStage) {

					for(int k=0; k < spr.Length; k++) 
						StartCoroutine(StageFadeOut(spr[k]));
	
					StopCoroutine("StageFadeOut");
					StartCoroutine(StageSmaller(mapStage[i]));
					StartCoroutine(StageRotateLeft(mapStage[i]));

				} else
					StartCoroutine(StageRotateLeft(mapStage[i]));
			}

			StopCoroutine("StageSmaller");
			StopCoroutine("StageBigger");
			StopCoroutine("StageRotateRight");
		}
	}

	// map fadeout
	IEnumerator StageFadeOut(SpriteRenderer s) {
		Color color = s.color;

		while(color.a > 0.5f) {
			color.a -= 0.05f;
			s.color = color;
			yield return null;
		}
	}

	// map fadein
	IEnumerator StageFadeIn(SpriteRenderer s) {
		Color color = s.color;

		while(color.a < 1.0f) {
			color.a += 0.05f;
			s.color = color;
			yield return null;
		}
	}

	// map bigger
	IEnumerator StageBigger(GameObject g) {
		float i = 0.02f;

		for(int j=0; j < 10; j++) {
			g.transform.localScale += new Vector3 (i, i, 0);
			yield return null;
		}
	}

	// map smaller
	IEnumerator StageSmaller(GameObject g) {
		float i = -0.02f;

		for(int j=0; j < 10; j++){
			g.transform.localScale += new Vector3 (i, i, 0);
			yield return null;
		}
	}

	// map rotate left
	IEnumerator StageRotateLeft(GameObject g) {
			float i = 6.0f;
			g.transform.RotateAround(rotatePivot, Vector3.forward, i);
			yield return null;
	}

	// map rotate right
	IEnumerator StageRotateRight(GameObject g) {
			float i = -6.0f;
			g.transform.RotateAround(rotatePivot, Vector3.forward, i);
			yield return null;
	}
}