using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

	public Texture2D muted;
	public Texture2D unmuted;
	bool check1 = false;
	bool mutedUnmuted = false;
	float timer = 0;
	float timerCheck = 0.5f;
	GameObject cameraVar;

	// Use this for initialization
	void Start () {
		cameraVar = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= timerCheck){
			changeMuting ();
		}
		timer += Time.deltaTime;
	}

	//void OnGUI(){
	//	if(Input.GetMouseButtonDown (0)){
	//		if(check1 == false){
	//			check1 = true;
	//		} else if( check1 == true){
	//		
	//		}
	//	}
	//}

	void OnMouseDown(){
			if(check1 == false){
			print ("something");
				check1 = true;
			} else if( check1 == true){								
			}

	}

	void changeMuting(){
		if(check1 == true){
			print ("something");
			if(mutedUnmuted == false){
				mutedUnmuted = true;
				check1 = false;
				timer = 0;
				(cameraVar.GetComponent<AudioListener>() as AudioListener).enabled = false;
				guiTexture.texture = muted;
			} else if( mutedUnmuted == true){
				mutedUnmuted = false;
				check1 = false;
				timer = 0;
				(cameraVar.GetComponent<AudioListener>() as AudioListener).enabled = true;
				guiTexture.texture = unmuted;
			}
		}
	}
}
