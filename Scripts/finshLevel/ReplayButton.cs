using UnityEngine;
using System.Collections;

public class ReplayButton : MonoBehaviour {
	
	
	//public AudioClip FloorFinshedAudio;
	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect (((Screen.width / 2) - 183f),/* yPosition = 597 */ ((Screen.height / 2) - 20.5f), 380, 117);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void loadLevel()
	{
			Application.LoadLevel("Main Scene Saboteur");
		
	}


	
	void OnMouseEnter()
	{
		//canFall = true;
		
	}
	void OnMouseExit()
	{
		

	}
	
	void OnMouseDown () 
	{			
		audio.Play();
		loadLevel();
	}








}
