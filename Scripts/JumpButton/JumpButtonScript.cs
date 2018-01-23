using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler , IPointerUpHandler{
	
	//When we hlod the button then we set the power equal to true
	public void OnPointerDown(PointerEventData data) {
		if(PlayerJumpScript.instance != null) {
			PlayerJumpScript.instance.setThePower(true);
		}
	}
	
	//When we hlod the button then we set the power equal to false
	public void OnPointerUp(PointerEventData data) {	
		if(PlayerJumpScript.instance != null) {
			PlayerJumpScript.instance.setThePower(false);
		}
	}
}
