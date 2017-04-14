using UnityEngine;
using System.Collections;

public class SpawningWorkers : MonoBehaviour {

	// Use this for initialization
	public Transform prefab;
	public Transform helmetWorker;
	public Transform bootsWorker;
	public float timeLeft = 2.0f;
	GameObject worker;
	int randomNr;
	public int spwaningCount = 30;
	float time;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnWorker ();	
		time += Time.deltaTime;
	}

	void spawnWorker(){
		timeLeft -= Time.deltaTime;
		if(LevelController.WorkerCount <= 80){
			if(timeLeft < 0)
			{
				randomNr = (int)Random.Range (0, spwaningCount);
				if(randomNr >= 0 && randomNr <= 4 ){
					Vector3 tmpVec = new Vector3(0, 0.05f, 0);
					
					Transform spawnedWorker = Instantiate (helmetWorker, (transform.position - tmpVec), transform.rotation) as Transform;
					spawnedWorker.gameObject.GetComponent<WorkerMovement>().type = 2;
					
				}
				
				else if(randomNr >= 4 && randomNr < 8 ){
						Vector3 tmpVec2 = new Vector3(0, 0.02f, 0);
					
					Transform spawnedWorker = Instantiate (bootsWorker,(transform.position - tmpVec2), transform.rotation) as Transform;
					spawnedWorker.gameObject.GetComponent<WorkerMovement>().type = 3;
				}
				
				else
				{
					
					Transform spawnedWorker = Instantiate (prefab, transform.position , transform.rotation) as Transform;
					spawnedWorker.gameObject.GetComponent<WorkerMovement>().type = 1;
				}
			
				if(time < 40){
					if(LevelController.WorkerCount < 20){
						timeLeft = UnityEngine.Random.Range(0.1f, 2.0f);
					} else {
						timeLeft = UnityEngine.Random.Range(0.1f, 4.0f);
					}
				} else if (time >= 40 && time < 70){
					if(LevelController.WorkerCount < 40){
						timeLeft = UnityEngine.Random.Range(0.1f, 2.0f);
					} else {
						timeLeft = UnityEngine.Random.Range(0.1f, 3.2f);
					}			
				} else if (time >= 70 && time < 120){
					if(LevelController.WorkerCount < 60){
						timeLeft = UnityEngine.Random.Range(0.1f, 1.0f);
					} else {
						timeLeft = UnityEngine.Random.Range(0.1f, 2.0f);
					}			
				} else if (time >= 120 ){
					if(LevelController.WorkerCount < 100){
						timeLeft = UnityEngine.Random.Range(0.1f, 0.6f);
					} else {
						timeLeft = UnityEngine.Random.Range(0.1f, 1.5f);
					}			
				}
				//	LevelController.SpawnWorker();
				int x;
				LevelController.AddWorker();	
			}
		}
	}
}
