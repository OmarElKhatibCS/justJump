using UnityEngine;
using System.Collections;

public class PlayerJumpScript : MonoBehaviour {

	public static PlayerJumpScript instance;
	
	private Animator anim;
	private Rigidbody2D myBody;
	
	[SerializeField]
	private float forceX,forceY;
	
	private float terSholdX = 7f;
	private float terSholdY = 14f;
	
	private bool setPower , didJump;
	
	//Awake is an function do in frames per milli second
	void Awake() {
		MakeInstance();
		Initialize();
	}
	
	//do an update Each Frame
	void Update() {
		SetPower();
	}
	
	//this function is for install information
	void Initialize() {
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	//this function is for make the instance
	void MakeInstance() {
		if(instance == null)
			instance = this;
	}
	
	//For set power by forces for Jumping
	void SetPower() {
		if(setPower) {
			forceX += terSholdX * Time.deltaTime;
			forceY += terSholdY * Time.deltaTime;
			
			if(forceX >= 6.5f)
				forceX = 6.5f;
			if(forceY >= 13.5f)
				forceY = 13.5f;
		}
	}
		
	//this is for set the power for our Hero
	public void setThePower(bool setPower) {
		this.setPower = setPower;
		
		if(!setPower)
			Jump();
	}
	
	//this function is for Jump
	void Jump() {
		myBody.velocity = new Vector2(forceX,forceY);
		forceX = forceY = 0f;
		didJump = true;
	}
	
	//this function if player was collide the platform as trigger
	void OnTriggerEnter2D(Collider2D target) {
		if(didJump) {
			didJump = false;
			
			if(target.tag == "Platform") {
				if(gameManager.instance != null) {
					gameManager.instance.createNewPlatformLerp(target.transform.position.x);
				}
				
				if(scoreManager.instance != null) {
					scoreManager.instance.incrementScore();
				}
				
			} 
			
			if(target.tag == "DedZone") {
				if(GameOverManager.instance != null) {
					GameOverManager.instance.showTheGameOverPanel();
					Destroy(gameObject);
				}
			}
			
		}
	}
	
}








