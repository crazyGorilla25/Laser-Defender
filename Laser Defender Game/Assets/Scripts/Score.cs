using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int score=0;
	Text myText;
	void Start(){
		myText=GetComponent<Text>();
		myText.text = "Score: " + score.ToString();
	}
	public void ScorePoints(int points){
		score += points;
		myText.text = "Score: " + score.ToString();
	}
	public static void Reset(){
		score = 0;
	}
}
