using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public static GameOverManager instance;
	
	private GameObject GameOverPanel;
	private Animator gameOverAnim;
	
	private GameObject scoreText;
	
	private Button backButton , replayButton;
	
	private Text finalScore;
	
	void Awake() {
		MakeInstance();
		IntiallizeObjects();
	}
	
	//Make the instance
	void MakeInstance() {
		if(instance == null)
			instance = this;
	}
	
	//install the variables
	void IntiallizeObjects() {
		GameOverPanel = GameObject.Find("Game Panel Holder");
		gameOverAnim = GameOverPanel.GetComponent<Animator>();
		backButton = GameObject.Find ("back button").GetComponent<Button>();
		replayButton = GameObject.Find("replay button").GetComponent<Button>();
		
		backButton.onClick.AddListener(() => backToMainMenu());
		replayButton.onClick.AddListener(() => replayGame());
		
		finalScore = GameObject.Find("final score").GetComponent<Text>();
		
		scoreText = GameObject.Find("score text");
		
		GameOverPanel.SetActive(false);
	}
	
	//this function is for show panel with animation
	public void showTheGameOverPanel() {
		scoreText.SetActive(false);
		GameOverPanel.SetActive(true);
		gameOverAnim.Play("fadIn");
		
		if(scoreManager.instance != null)
			finalScore.text = "Score \n" + scoreManager.instance.getScore();
	}
	
	//replay function for button
	public void replayGame() {
		Application.LoadLevel("Game");
	}
	
	//back to main menu function for button
	public void backToMainMenu() {
		Application.LoadLevel("Main");
	}
}
