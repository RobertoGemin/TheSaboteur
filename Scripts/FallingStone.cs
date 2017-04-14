using UnityEngine;
using System.Collections;

public class FallingStone : MonoBehaviour {
	
	
	GameObject gameObjectfHithead;
	public GameObject prefabsHitheadLeft;
		public GameObject prefabsBootsHitheadLeft;
	//public GameObject prefabsHithead;
	
	// Use this for initialization
	public AudioClip fallingstonehead; 
	float stoneFallingValue = -1.0f;
	float stoneFalling = 0f;
	public bool canFall = false;
	Vector3 temp ;
	float timerMax = 0.3f;
	float timerCount = 0f;

	//Timer for the brick after it hits a worker
	bool startTimer = false;
	float hitTimer = 0f;
	float hitAliveTime = 0.05f;
	float gravityConstant = 10f;
	
	void Start () {
		//standaard kleur 
		//renderer.material.color = Color.gray;
		// Kopie maken van de positie.
		temp = transform.position; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(canFall)
		{
			transform.Translate (0,stoneFallingValue * Time.deltaTime, 0);
			stoneFallingValue -= gravityConstant * Time.deltaTime;
			timerCount += Time.deltaTime;
		//	print (stoneFallingValue);
		}	
		DestroyStone ();
	}
	
		
	void OnMouseEnter()
	{
		//renderer.material.color = Color.red;
		//canFall = true;
		
	}
	void OnMouseExit()
	{
		
		//renderer.material.color = Color.gray;
		
	}
	
	void OnMouseDown () 
	{
			//renderer.material.color = Color.red;
			canFall = true;
		
	}
	

	void OnCollisionEnter(Collision collision)
	{
		// respawing van de steen.
		//print ("true");
		if (collision.gameObject.tag == "concrete") 
		{
			if(timerCount >= timerMax){
				canFall = false;
				//breng de steen terug
				//transform.position = temp;
				Destroy(transform.parent.gameObject);
				Destroy (gameObject);
			}
		}
		// kill the worker
		if (collision.gameObject.tag == "workers") 
		{
			if(collision.gameObject.GetComponent<WorkerMovement>().type == 1){
				collision.gameObject.GetComponent<WorkerMovement>().removeWorkerFloor ();
				StaticAudio.PlaybrickToHead();
				Destroy(collision.gameObject);
				LevelController.KillWorker();
				startTimer = true;
				
				gameObjectfHithead = Instantiate (prefabsHitheadLeft, collision.transform.position, Quaternion.identity) as GameObject;
				
				
			} else if (collision.gameObject.GetComponent<WorkerMovement>().type == 2){
				startTimer = true;
			}
			else // type 3
			{
				collision.gameObject.GetComponent<WorkerMovement>().removeWorkerFloor ();
				StaticAudio.PlaybrickToHead();
				Destroy(collision.gameObject);
				LevelController.KillWorker();
				startTimer = true;
				
				gameObjectfHithead = Instantiate (prefabsBootsHitheadLeft, collision.transform.position, Quaternion.identity) as GameObject;
				
				
				
			}
		}
	}

	void DestroyStone(){
		if(startTimer == true)
		{
			hitTimer += Time.deltaTime;
			if(hitTimer >= hitAliveTime)
			{
				//transform.parent.gameObject.GetComponent<SpawnBricks>().brickPresent = false;
				Destroy(transform.parent.gameObject);
				//breng de steen terug
				//audio.Play();
				//transform.position = temp;
				hitTimer = 0;
				startTimer = false;
				canFall = false;
				Destroy (gameObject);

			}
		}
	}
}
