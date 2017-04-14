using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	
	//public AudioClip FloorFinshedAudio;
	// Use this for initialization
	void Start () {
		guiTexture.pixelInset = new Rect (((Screen.width / 2) - 215f),/* yPosition = 597 */ ((Screen.height / 20) * 12.9375f), 430, 132);
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
