using UnityEngine;
using System.Collections;

public class plankFallingWorkers : MonoBehaviour {
	
	GameObject gameObjectfFalling;
	public GameObject prefabsFallingLeft;
	public GameObject HelmetprefabsFallingLeft;
	public GameObject BootsprefabsFallingLeft;
	public int typeWorker;
	
	// Use this for initialization
	void Start () {
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
	
		// kill the worker
		if (collision.gameObject.tag == "workers") 
		{
			collision.gameObject.GetComponent<WorkerMovement>().removeWorkerFloor();
			typeWorker = collision.gameObject.GetComponent<WorkerMovement>().getWorkerIndex();
			StaticAudio.HitPlankFalling();
			if(typeWorker == 1)
			{
				gameObjectfFalling = Instantiate (prefabsFallingLeft, collision.transform.position, Quaternion.identity) as GameObject;
			}
			else if(typeWorker == 2)
			{
				gameObjectfFalling = Instantiate (HelmetprefabsFallingLeft, collision.transform.position, Quaternion.identity) as GameObject;
			}
			else
			{
				gameObjectfFalling = Instantiate (BootsprefabsFallingLeft, collision.transform.position, Quaternion.identity) as GameObject;
				
			}
				
			Destroy(collision.gameObject);
			LevelController.KillWorker();
		}
	}
		
		
		

}
