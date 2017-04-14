// !! belangerijk
// !!tags toevoegen in de edior 

using UnityEngine;
using System.Collections;

public class WorkerMovement : MonoBehaviour 
{
	private Animator animator;
	// belangerijk voorde animatie
	public int type;

	float movementValue = 1.25f;
	float movement = 0f;
	float tempMovement = 0f;
	bool ladderUse = false; // check if ladder use.
	bool walkUpValue = false; // gaat laag./het is de doos dat boven je aanraakt
	bool walkDownValue = false;//gaat omhoog./het is de doos dat onderaanraakt
	bool startTimer = false;
	float hitTimer = 0f;
	float hitAliveTime = 1.28f;
	int currentFloor = 1;
	bool canGoUp = false;
	bool canGoDown = false;
	GameObject cameraVar;
	
	
	void Start () 
	{
		
		animator = this.GetComponent<Animator>();
	
		animator.SetInteger("Direction", 1);
		movement = -movementValue;
		LevelController.workersOnFloor1 += 1;
		cameraVar = GameObject.Find ("Main Camera");
	}
	
	void Update () 
	{
		   
		
		if (ladderUse)
		{
			moveWorkerup();		
		}
		else
		{
		//	
			transform.Translate (movement * Time.deltaTime, 0, 0);
		}
	}
	void checkLadder()
	{
		// hier moet de timmer van lader uitvoeren		
		hitTimer += Time.deltaTime;
		if(hitTimer >= hitAliveTime)
		{	
			hitTimer = 0;
			ladderUse = false;
			walkDownValue = false;
			changePosition();
		}
		else
		{
			if (walkDownValue)
			{
				animator.SetInteger("Direction", 1);
				transform.Translate (0, 0, movement * Time.deltaTime);
			}
			else
			{
				animator.SetInteger("Direction", 3);
				transform.Translate (0, 0,-movement * Time.deltaTime);			
			}
		}
	}
	
	void changeMovement()
	{
		if(movement < 0)
		{
			//print("collison chang movent");
			 animator.SetInteger("Direction", 3);
			movement = movementValue;
		} 
		else 
		{
			 animator.SetInteger("Direction", 1);
			movement = -movementValue;
		}
		tempMovement = movement;
		
	}
	
	
	void changePosition()
	{
		if(movement < 0)
		{
			
			 animator.SetInteger("Direction", 1);
			
		} 
		else 
		{
			 animator.SetInteger("Direction", 3);
			
		}
		
		
	}
	
	
	
	void OnCollisionEnter(Collision collision)
	{		
		if (collision.gameObject.tag == "wall") // Als de worker tegen een muur aanloop, draai de beweging om en loop de andere kant op.
		{		
			changeMovement();
		}	

		if(collision.gameObject.tag == "error"){
			removeWorkerFloor();
			Destroy (gameObject);
		}

		// This one goes up!
		if (collision.gameObject.tag == "ladderDown") 
		{		
			if(ladderUse == false) //start timmer
			{
				if(transform.position.x > collision.transform.position.x + 0.17f){
					checkGoUp ();
					if(canGoUp == true){
						ladderUse = true;
						walkDownValue = false;
						walkUpValue = true;
						hitTimer = 0;	
						changeMovement();
						ladderFloorUp (); // Press f-12 with the cursor on the method.
						canGoUp = false;
					} else if(cameraVar.GetComponent<Spawnfloors>().floorList[currentFloor-1].GetComponent<FloorScript>().isFinished == true){
						ladderUse = true;
						walkDownValue = false;
						walkUpValue = true;
						hitTimer = 0;	
						changeMovement();
						ladderFloorUp (); // Press f-12 with the cursor on the method.
						canGoUp = false;
					}
				}
			}
		}
		// This one goes down!
		else if (collision.gameObject.tag == "ladderUp") 
		{	
			if(transform.position.x > collision.transform.position.x + 0.17f){
				if(ladderUse == false) //start timmer
				{
					checkGoDown ();
					if(canGoDown == true){
						ladderUse = true;
						walkDownValue = true;
						walkUpValue = false;
						hitTimer = 0;
						changeMovement(); 
						ladderFloorDown (); // Press f-12 with the cursor on the method.
						canGoDown = false;
					}
				}
			}
		}
		else if (collision.gameObject.tag == "ladderDownRight") 
		{		
			if(transform.position.x < collision.transform.position.x - 0.17f){
				if(ladderUse == false) //start timmer
				{
					checkGoUp ();
					if(canGoUp == true){
						ladderUse = true;
						walkDownValue = false;
						walkUpValue = true;
						hitTimer = 0;	
						changeMovement();
						ladderFloorUp (); // Press f-12 with the cursor on the method.
						canGoUp = false;
					} else if(cameraVar.GetComponent<Spawnfloors>().floorList[currentFloor-1].GetComponent<FloorScript>().isFinished == true){
						ladderUse = true;
						walkDownValue = false;
						walkUpValue = true;
						hitTimer = 0;	
						changeMovement();
						ladderFloorUp (); // Press f-12 with the cursor on the method.
						canGoUp = false;
					}
				}
			}
		}
		// This one goes down!
		else if (collision.gameObject.tag == "ladderUpRight") 
		{	
			if(transform.position.x < collision.transform.position.x - 0.17f){
				if(ladderUse == false) //start timmer
				{
					checkGoDown ();
					if(canGoDown == true){
						ladderUse = true;
						walkDownValue = true;
						walkUpValue = false;
						hitTimer = 0;
						changeMovement(); 
						ladderFloorDown (); // Press f-12 with the cursor on the method.
						canGoDown = false;
					}
				}
			}
		}
	}

	void moveWorkerup()
	{
			hitTimer += Time.deltaTime;	// hier moet de timmer van lader uitvoeren		
			if(hitTimer >= hitAliveTime)
			{
				hitTimer = 0;
				ladderUse = false;
				walkDownValue = false;
				walkUpValue = false;
				changePosition();
			 	// hier moet ik de movent toevoegen.
			}
			else
			{
				if (walkDownValue)// ladder event.
				{
					animator.SetInteger("Direction", 2);
					transform.Translate (0,  -1.28f * Time.deltaTime,0);
					 
				}
				else
				{
					animator.SetInteger("Direction", 2);
					transform.Translate (0,  1.28f * Time.deltaTime,0);			
				}
			}
		
	}

	void ladderFloorUp(){
		if (currentFloor == 1) {
			LevelController.workersOnFloor1 -= 1;
			currentFloor = 2;
			LevelController.workersOnFloor2 += 1;
		} else if (currentFloor == 2){
			LevelController.workersOnFloor2 -= 1;
			currentFloor = 3;
			LevelController.workersOnFloor3 += 1;
		} else if (currentFloor == 3){
			LevelController.workersOnFloor3 -= 1;
			currentFloor = 4;
			LevelController.workersOnFloor4 += 1;
		} else if (currentFloor == 4){
			LevelController.workersOnFloor4 -= 1;
			currentFloor = 5;
			LevelController.workersOnFloor5 += 1;
		}
	}

	void ladderFloorDown(){
		if (currentFloor == 5) {
			LevelController.workersOnFloor5 -= 1;
			currentFloor = 4;
			LevelController.workersOnFloor4 += 1;
		} else if (currentFloor == 4){
			LevelController.workersOnFloor4 -= 1;
			currentFloor = 3;
			LevelController.workersOnFloor3 += 1;
		} else if (currentFloor == 3){
			LevelController.workersOnFloor3 -= 1;
			currentFloor = 2;
			LevelController.workersOnFloor2 += 1;
		} else if (currentFloor == 2){
			LevelController.workersOnFloor2 -= 1;
			currentFloor = 1;
			LevelController.workersOnFloor1 += 1;
		}
	}

	void checkGoUp(){
		int tmpInt = 0;
		tmpInt = (int)Random.Range (0,10);
		if(currentFloor == 1){
			if(LevelController.workersOnFloor1 > LevelController.workersOnFloor2 + 1){
				if(tmpInt <= 6){
					canGoUp = true;
				}
			 	else {
					canGoUp = false;
				}
			}else {
				canGoUp = false;
			}
		} else if(currentFloor == 2){
			if(LevelController.workersOnFloor2 > LevelController.workersOnFloor3 + 1){
				if(tmpInt <= 6){
					canGoUp = true;
				}
				else {
					canGoUp = false;
				}
			} else {
				canGoUp = false;
			}
		} else if(currentFloor == 3){
			if(LevelController.workersOnFloor3 > LevelController.workersOnFloor4 + 1){
				if(tmpInt <= 6){
					canGoUp = true;
				}
				else {
					canGoUp = false;
				}
			}else {
				canGoUp = false;
			}
		} else if(currentFloor == 4){
			if(LevelController.workersOnFloor4 > LevelController.workersOnFloor5 + 1){
				if(tmpInt <= 6){
					canGoUp = true;
				}
				else {
					canGoUp = false;
				}
			} else {
				canGoUp = false;
			}
		}
	}

	void checkGoDown(){
		int tmpInt1 = 0;
		tmpInt1 = (int)Random.Range (0, 10);
		if(cameraVar.GetComponent<Spawnfloors>().floorList[(currentFloor - 2)].GetComponent<FloorScript>().isFinished == true){
			canGoDown = false;
			} else {
			if(tmpInt1 <= 6){
				canGoDown = true;
			} else {
				canGoDown = false;
			}
		}
	}
	
	public int getWorkerIndex()
	{
		
		return type;
		
	}
	public void removeWorkerFloor(){
		if(currentFloor == 1){
			LevelController.workersOnFloor1 -= 1;
		} else if(currentFloor == 2){
			LevelController.workersOnFloor2 -= 1;
		} else if(currentFloor == 3){
			LevelController.workersOnFloor3 -= 1;
		} else if(currentFloor == 4){
			LevelController.workersOnFloor4 -= 1;
		} else if(currentFloor == 5){
			LevelController.workersOnFloor5 -= 1;
		}
		}
}
