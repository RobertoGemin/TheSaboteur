using UnityEngine;
using System.Collections;

public class collisonWireKillWorker : MonoBehaviour {
	
	public int typeWorker;
	GameObject gameObjectfElect;
	public GameObject animatieDie;
	public GameObject HelmetanimatieDie;
	public  AudioClip electricSound;  
	
	
	void Start () {
		
		
		audio.clip = electricSound;
		audio.Play();
		
		
	}
	
	
	
	
	void Update () {
		
	
	}
	void OnCollisionEnter(Collision collision)
	{
	
		// kill the worker
		if (collision.gameObject.tag == "workers") 
		{
			collision.gameObject.GetComponent<WorkerMovement>().removeWorkerFloor();
			LevelController.KillWorker();			
			typeWorker = collision.gameObject.GetComponent<WorkerMovement>().getWorkerIndex();
			if (typeWorker == 1)
			{
				Destroy(collision.gameObject);
				gameObjectfElect = Instantiate (animatieDie, collision.transform.position, Quaternion.identity) as GameObject;
				//
				
			}
			else if (typeWorker == 2)
			{
				Destroy(collision.gameObject);
				gameObjectfElect = Instantiate (HelmetanimatieDie, collision.transform.position, Quaternion.identity) as GameObject;
			}
			else 
			{
				// do nothing bitch
				
			}
		}
	}
		
		
		

}
