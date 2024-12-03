﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreDisplay : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int score = FindObjectOfType<ScoreAbsorber>().score;
		text.text = "Score: " + score;
	}
}
