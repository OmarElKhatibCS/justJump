using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

	public static scoreManager instance;
	
	 private Text scoreText;
	 private int score;
	 
	 void Awake() {
	 	MakeInstance();
		scoreText = GameObject.Find("score text").GetComponent<Text>();
	 }
	 
	 void MakeInstance() {
	 	if(instance == null)
	 		instance = this;
	 }
	 
	 //add the score
	 public void incrementScore() {
	 	score++;
	 	scoreText.text = "" + score;
	 }
	 
	 //return the score
	 public int getScore() {
	 	return this.score;
	 }
}
