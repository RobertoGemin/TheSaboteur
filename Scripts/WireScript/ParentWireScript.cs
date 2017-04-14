using UnityEngine;
using System.Collections;

public class ParentWireScript : MonoBehaviour {

	// Use this for initialization
	public int parentWireStatus = 0;
	public GameObject Wirestatus_1;
	public GameObject Wirestatus_2;
	public GameObject Wirestatus_3;
	
	
	bool startTimer = false;
	public float hitTimer = 0f;
	float hitAliveTime = 2f;
	
	
	// Use this for initialization
	void Start ()
	{
		startTimer = false;
		parentWireStatus = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangStatus();
		timerChange();
	
	}
	
	void OnMouseDown () 
	{
	if (parentWireStatus == 0)
		{
			
			parentWireStatus = 1;
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
				
				if (parentWireStatus == 1)
				{
					parentWireStatus = 2;
					hitTimer = 0;
					
				}
			}if(hitTimer >= hitAliveTime * 12){
				if  (parentWireStatus == 2)
					{
					startTimer = false;
					parentWireStatus = 0;
					hitTimer = 0;
					}

			}
		}	
		
		
	}
	
	
	void ChangStatus()
	{
		
		if (parentWireStatus == 0)
		{
		
			Wirestatus_1.SetActive(true); 
	 		Wirestatus_2.SetActive (false);
			Wirestatus_3.SetActive (false);
			
			
		}
		else if(parentWireStatus == 1)
		{
			Wirestatus_1.SetActive(false); 
	 		Wirestatus_2.SetActive (true);
			Wirestatus_3.SetActive (false);
			
			
		}
		else
		{
			Wirestatus_1.SetActive(false); 
	 		Wirestatus_2.SetActive (false);
			Wirestatus_3.SetActive (true);	
			
		}
		
	}
	
}
