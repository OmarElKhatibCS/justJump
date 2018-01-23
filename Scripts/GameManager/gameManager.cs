using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager instance;
	
	[SerializeField]
	private GameObject Player;
	
	[SerializeField]
	private GameObject Platform;
	
	private float minX = -2.5f ,maxX = 2.5f ,minY = -4.7f , maxY = -3.7f;
	private bool lerpCamera;
	private float lerpX;
	private float lerpTime = 1.5f;
	
	void Awake() {
		makeInstance();
		createInitialePlatform();
	}
	
	void Update() {
		if(lerpCamera)
			lerpTheCamera();
	}
	
	//Make the instance
	void makeInstance() {
		if(instance == null)
			instance = this;
	}
	
	//this function is for create the objects (Player $ Platforms)
	void createInitialePlatform() {
		Vector3 temp = new Vector3(Random.Range(minX,minX+1.2f) , Random.Range(minY,maxY) ,0);
		Instantiate(Platform,temp , Quaternion.identity);
		
		temp.y += 1.5f;
		temp.z = -1;
		Instantiate(Player,temp,Quaternion.identity);
		
		temp = new Vector3(Random.Range(maxX , maxX-1.2f) , Random.Range(minY,maxY), 0);
		Instantiate(Platform,temp,Quaternion.identity);
	}
	
	//create the new lerp platform
	public void createNewPlatformLerp(float lerpPosition) {
		createNewPlatforms();
		
		lerpX = lerpPosition + maxX;
		lerpCamera = true;
	}
	
	//this is for update the position of the camera **Important**
	void lerpTheCamera() {
		float x = Camera.main.transform.position.x;
		x = Mathf.Lerp(x,lerpX,lerpTime * Time.deltaTime);
		
		Vector3 temp = new Vector3(x ,Camera.main.transform.position.y, Camera.main.transform.position.z);
		Camera.main.transform.position = temp;
		
		if(Camera.main.transform.position.x >= lerpX - 0.07f )
			lerpCamera = false;
	}
	
	//this dunction is for create the new platforms
	void createNewPlatforms() {
		float cameraX = Camera.main.transform.position.x;
		
		float newMaxX = cameraX + (maxX * 2f);
		
		Vector3 newCameraPosition = new Vector3(Random.Range(newMaxX , newMaxX-1f) , Random.Range(maxY,maxY-1.2f) , 0);
		
		Instantiate(Platform,newCameraPosition,Quaternion.identity);
	}
	
}
