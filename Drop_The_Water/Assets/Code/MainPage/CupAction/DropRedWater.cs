using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRedWater : MonoBehaviour {

	GameObject minusCup;
	int i, j;

	void Start () {
		i = stageManager.instance.cupIndex;
		j = makeStage.answerNum[i];
		minusCup = makeStage.gameCup[i];
		stageManager.instance.drop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
	}

	void Update () {
		
		if (!stageManager.instance.drop) {
			stageManager.instance.drop = true;
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.tag.Equals("empty"))
		{
			//direction = minusCup.transform.position;
			//Debug.Log ("minusCup gameobject is cup");

			if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_8")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_7");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_7")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_6");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_6")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_5");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_5")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_4");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_4")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_3");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_3")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_2");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_2")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_1");
			}else if (minusCup.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_1")) {
				minusCup.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_0");
			}

			//Destroy(this.gameObject);

			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

			this.gameObject.transform.position = stageManager.instance.red_waterPos;

			stageManager.instance.finalDrop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);

			if(stageManager.instance.finalDrop) {
				makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_"+makeStage.answerNum[i]);
				Destroy(this.gameObject);
			} else
				stageManager.instance.drop = false;
		}
	}
}