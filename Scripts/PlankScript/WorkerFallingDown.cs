using UnityEngine;
using System.Collections;

public class WorkerFallingDown : MonoBehaviour {
	
	
	GameObject gameObjectFallingDie;
	public GameObject prefabsFallingFallingDie;
	
	public float fallingValue = -2.25f;
	float timerMax = 0.5f;
	float timerCount = 0f;
	
	bool checkhitFirst = false;

	// Use this for initialization
	void Start () {
		
	// start timeer
		
	}
	
	// Update is called once per frame
	void Update () {
		fallingDown();	
		
	}
	
	void fallingDown()
	{
		
		transform.Translate (0, fallingValue * Time.deltaTime,0 );
		timerCount += Time.deltaTime;
		
	}
	void OnCollisionEnter(Collision collision)
	{
		// respawing van de steen.
		if (collision.gameObject.tag == "concrete") 
		{

			if (timerCount >= timerMax)
			{
				print("print check hit die");
				Destroy(gameObject);
				gameObjectFallingDie = Instantiate (prefabsFallingFallingDie,transform.position, Quaternion.identity) as GameObject;
			}
		}
	}
	//transform.Translate (0, 0, movement * Time.deltaTime);
	
}
