﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text> ();
		myText.text = "You got " + Score.score.ToString () + " points!";
		Score.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
