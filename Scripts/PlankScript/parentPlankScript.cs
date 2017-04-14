using UnityEngine;
using System.Collections;

public class parentPlankScript : MonoBehaviour {
	
	
	public int parentPlankStatus = 0;
	public GameObject Plankstatus_1;
	public GameObject Plankstatus_2;
	public GameObject Plankstatus_3;
	
	
	bool startTimer = false;
	float hitTimer = 0f;
	float hitAliveTime = 2.5f;
	
	
	// Use this for initialization
	void Start ()
	{
		if(transform.parent.gameObject.GetComponent<FloorScript>().floorID == 5){
			parentPlankStatus = 2;
		} else {
			parentPlankStatus = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangStatus();
		timerChange();
	
	}
	
	void OnMouseDown () 
	{
	if (parentPlankStatus == 0)
		{
			
			parentPlankStatus = 1;
			//startTimer
			startTimer = true;
			hitTimer = 0;
		}
		
	}
	
	void timerChange()
	{
		if(startTimer == true)
			{
				hitTimer += Time.deltaTime;
				if(hitTimer >= hitAliveTime)
				{
				
		
					if (parentPlankStatus == 1)
					{
						parentPlankStatus = 2;
						hitTimer = 0;
						
					}
				if(hitTimer >= hitAliveTime * 10){
					if  (parentPlankStatus == 2)
					{
							startTimer = false;
							parentPlankStatus = 0;
							hitTimer = 0;
					}
				}
			}	
		}
	}
	
	
	void ChangStatus()
	{
		
		if (parentPlankStatus == 0)
		{
		
			Plankstatus_1.SetActive(true); 
	 		Plankstatus_2.SetActive (false);
			Plankstatus_3.SetActive (false);
			
			
		}
		else if(parentPlankStatus == 1)
		{
			Plankstatus_1.SetActive(false); 
	 		Plankstatus_2.SetActive (true);
			Plankstatus_3.SetActive (false);
			
			
		}
		else
		{
			Plankstatus_1.SetActive(false); 
	 		Plankstatus_2.SetActive (false);
			Plankstatus_3.SetActive (true);
			
			
			
		}
		
	}
	
	
	
}
