using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public Texture2D play;
	public Texture2D pause;
	bool check1 = false;
	bool playPause = false;
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
			changePlayPause ();
		}
		timer += Time.deltaTime;
	}

	void OnMouseDown(){
			if(check1 == false){
				check1 = true;
			} else if( check1 == true){
			
			}
	}

	void changePlayPause(){
		if(check1 == true){
			print ("something");
			if(playPause == false){
				playPause = true;
				check1 = false;
				Time.timeScale = 0;
				(cameraVar.GetComponent<AudioListener>() as AudioListener).enabled = false;
				guiTexture.texture = play;
			} else if( playPause == true){
				playPause = false;
				check1 = false;
				timer = 0;
				Time.timeScale = 1;
				(cameraVar.GetComponent<AudioListener>() as AudioListener).enabled = true;
				guiTexture.texture = pause;
			}
		}
	}
}
