using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = scoreKeeper.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
