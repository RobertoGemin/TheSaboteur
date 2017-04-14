using UnityEngine;
using System.Collections;

public class StaticAudio : MonoBehaviour {
	
	
	public  AudioClip fallingstonehead;  
	public static bool falingSound = false;
	
	public  AudioClip fallingFloorhead;  
	public static bool falingFloorheadSound = false;
	
	public  AudioClip electricSound;  
	public static bool boolelectricSound = false;
	
	
	public  AudioClip FallingHole;  
	public static bool boolFallingHole = false;
	
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (falingSound == true)
		{
			//print("Play audio....\\ ");
			audio.clip = fallingstonehead;
			audio.Play();
			falingSound = false;
		}	
		
		if (falingFloorheadSound == true)
		{
			audio.clip = fallingFloorhead;
			audio.Play();
			falingFloorheadSound = false;
		}
		
		
		
		if (boolelectricSound == true)
		{
			audio.clip = electricSound;
			audio.Play();
			boolelectricSound = false;
		}
		
			if (boolFallingHole == true)
		{
			audio.clip = FallingHole;
			audio.Play();
			boolFallingHole = false;
		}
		
		
	}
	
	void test()
	{
	audio.clip = fallingstonehead;
	audio.Play();
		
	}
	public static void PlaybrickToHead()
    {
		//print("headSomething ");
		falingSound = true;	
	//audio.clip = fallingstonehead;
	
		
	}
	
	public static void Hithead()
    {
		//print("headSomething ");
		falingFloorheadSound = true;	
	}
	
		public static void HitPlankFalling()
    {
		//print("headSomething ");
		boolFallingHole = true;	
	//audio.clip = fallingstonehead;
	
		
	}
	
	
}
