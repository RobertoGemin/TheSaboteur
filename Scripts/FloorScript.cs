using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	
	
	public AudioClip FloorFinshedAudio;
	public AudioClip EndLevel;
	
	public float floorProgress;
	GameObject staticObject;
	public float floorFinished;
	float extraFloor = 25;
	float sprite1Check = 1;
	float sprite2Check = 1.1f;
	float sprite3Check = 5;
	float sprite4Check = 10;
	float sprite6Check = 50;
	float sprite7Check = 75;
	float sprite8Check = 100;
	public int floorID;
	GameObject cameraVar;
	GameObject rendererVar;
	Spawnfloors spawnSc;
	bool nextFloor = false;
	public bool isFinished = false;
	bool sprite1 = false;
	bool sprite2 = false;
	bool sprite3 = false;
	bool sprite4 = false;
	bool sprite5 = false;
	bool sprite6 = false;
	bool sprite7 = false;
	bool sprite8 = false;
	public Material zeroPercent;
	public Material onePercent;
	public Material fivePercent;
	public Material tenPercent;
	public Material twentyFivePercent;
	public Material fiftyPercent;
	public Material seventyFivePercent;
	public Material hundredPercent;
	GameObject brickSpawnerLeft;
	GameObject brickSpawnerMid;
	GameObject brickSpawnerRight;
	GameObject[] brickList;
	GameObject floorPlank;
	GameObject floorWire;
	
	bool startTimer = false;
	float hitTimer = 0f;
	float hitAliveTime = 5.1f;

	//function motherFat (){
	//	if (mother == fat) {
	//		yourMother = NielsMother
	//	};
	//}
	
	// Use this for initialization

	// Use this for initialization
	void Start () {
		if(staticObject == null){
			staticObject = GameObject.Find ("STATIC SCORE");
		}
		floorProgress = 1;
		floorFinished = 100;
		cameraVar = GameObject.Find ("Main Camera");
		spawnSc = cameraVar.GetComponent<Spawnfloors>();
		nextFloor = false;
		InvokeRepeating("addProgress", 0.25f, 0.25f);
		foreach (Transform child in transform)
		{
			if(child.gameObject.name == "Level"){
				rendererVar = child.gameObject;
			}
			else if(child.gameObject.name == "BrickSpawnerLeft"){
				brickSpawnerLeft = child.gameObject;
			}
			else if(child.gameObject.name == "BrickSpawnerMid"){
				brickSpawnerMid = child.gameObject;
			}
			else if(child.gameObject.name == "BrickSpawnerRight"){
				brickSpawnerRight = child.gameObject;
			}
			
			else if(child.gameObject.name == "plank"){
				floorPlank = child.gameObject;
			}
			else if(child.gameObject.name == "wire"){
				floorWire = child.gameObject;
			}
			
		}
		brickSpawnerLeft.SetActive (false);
		brickSpawnerMid.SetActive (false);
		brickSpawnerRight.SetActive (false);
		floorPlank.SetActive(false);
		floorWire.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//addProgress ();
		spawnNextFloor ();
		checkEnd ();
		checkFinished ();
		handleSprites ();
		endGame();
	
	}

	void spawnNextFloor(){
		if (floorProgress >= extraFloor && nextFloor == false && spawnSc.floorList.Count < spawnSc.maximumFloorCount) {
			spawnSc.AddFloor();
			if(transform.gameObject == spawnSc.floorList[0]){
				spawnSc.ladder1.SetActive(true);
			} else if(transform.gameObject == spawnSc.floorList[1]){
				spawnSc.ladder2.SetActive(true);
			} else if(transform.gameObject == spawnSc.floorList[2]){
				spawnSc.ladder3.SetActive(true);
			} else if(transform.gameObject == spawnSc.floorList[3]){
				spawnSc.ladder4.SetActive(true);
			} 
			nextFloor = true;
			audio.clip = FloorFinshedAudio;
			audio.Play();
		}
	}

	void checkFinished(){
		if (floorProgress >= floorFinished) {
			isFinished = true;
		}
	}

	void handleSprites(){	
		if(floorProgress >= sprite1Check && floorProgress < sprite2Check && sprite1 == false){
			sprite1 = true;
			rendererVar.renderer.material = zeroPercent;
		} else if ( floorProgress >= sprite2Check && floorProgress < extraFloor && sprite2 == false){
			sprite2 = true;
			rendererVar.renderer.material = onePercent;
			brickSpawnerLeft.SetActive (true);
		} else if ( floorProgress >= sprite3Check && floorProgress < sprite4Check && sprite3 == false){
			sprite3 = true;
			rendererVar.renderer.material = fivePercent;
			brickSpawnerRight.SetActive (true);
		} else if ( floorProgress >= sprite4Check && floorProgress < extraFloor && sprite4 == false){
			sprite4 = true;
			rendererVar.renderer.material = tenPercent;
			brickSpawnerMid.SetActive(true);
		
			
		} else if ( floorProgress >= extraFloor && floorProgress < sprite6Check && sprite5 == false){
			sprite5 = true;
			rendererVar.renderer.material = twentyFivePercent;
			
			floorPlank.SetActive(true);
		} else if ( floorProgress >= sprite6Check && floorProgress < sprite7Check && sprite6 == false){
			sprite6 = true;
			
			
			rendererVar.renderer.material = fiftyPercent;
		} else if ( floorProgress >= sprite7Check && floorProgress < sprite8Check && sprite7 == false){
			sprite7 = true;
			rendererVar.renderer.material = seventyFivePercent;
		} else if ( floorProgress >= sprite8Check && sprite8 == false){
			sprite8 = true;
			rendererVar.renderer.material = hundredPercent;
			brickList = GameObject.FindGameObjectsWithTag ("stone");
			foreach(GameObject brick in brickList){
				//print (brick.transform.position);
				if(brick.transform.position.y <= (brickSpawnerLeft.transform.position.y + 0.5f) && brick.transform.position.y >= (brickSpawnerLeft.transform.position.y - 0.5f) || brick.transform.position.y <= (brickSpawnerMid.transform.position.y + 0.5f)  && brick.transform.position.y >= (brickSpawnerMid.transform.position.y - 0.5f) || brick.transform.position.y <= (brickSpawnerRight.transform.position.y +0.5f) && brick.transform.position.y >= (brickSpawnerRight.transform.position.y -0.5f)) {
					Destroy (brick);
				}
			}
			brickSpawnerLeft.SetActive(false);
			brickSpawnerMid.SetActive(false);
			brickSpawnerRight.SetActive(false);
			floorPlank.SetActive(false);
			floorWire.SetActive(true);
		}
	}

	void addProgress(){
		if(floorProgress >= 100){
			floorProgress= 100;
		} else {
			if(transform.gameObject == spawnSc.floorList[0]){
				floorProgress += LevelController.workersOnFloor1 * 0.03f;
			} else if (transform.gameObject == spawnSc.floorList[1]){
				floorProgress += LevelController.workersOnFloor2 * 0.03f;
			} else if (transform.gameObject == spawnSc.floorList[2]){
				floorProgress += LevelController.workersOnFloor3 * 0.03f;
			} else if (transform.gameObject == spawnSc.floorList[3]){
				floorProgress += LevelController.workersOnFloor4 * 0.03f;
			} else if (transform.gameObject == spawnSc.floorList[4]){
				floorProgress += LevelController.workersOnFloor5 * 0.03f;
			}
		}
	}

	void checkEnd() {
		if(floorID == spawnSc.maximumFloorCount)
		{
			if(floorProgress >= 100){
				startTimer = true;
				
				//hitTimer = 0;
				StartCoroutine(TestCoroutine());
			}
		}
	}

	
	
	
	IEnumerator TestCoroutine()
	{
 		audio.clip = EndLevel;
		audio.Play();
		Debug.Log ("Play sound.");
		
    	yield return new WaitForSeconds(2);
		    Debug.Log ("Just waited 1 second");
		resetVaribale();
		Destroy(GameObject.FindWithTag("workers"));
		Application.LoadLevel("FinshLevel");
	    yield break;
    	Debug.Log ("You'll never see this"); // produces a dead code warning
 	}
	
	
	
	void endGame(){
		
		if(startTimer == true)
		{
			
			hitTimer += Time.deltaTime;
			if(hitTimer >= hitAliveTime)
			{
				
			//print ("The game has ended");
			
		
			}
		}

	 
		
	}
	void resetVaribale()
	{
		LevelController.floorCount = 1;
		LevelController.maxFloor = 1;
	
		LevelController.WorkerCountTotal = 1;
		LevelController.WorkerCount = 1;
		LevelController.WorkerKilled = 0;
		
		
		
	}
}
