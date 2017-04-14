using UnityEngine;
using System.Collections;

public class SpawnBricks : MonoBehaviour {


	public GameObject brickPrefab;
	public bool brickPresent = false;
	float respawnTime = 3.5f;
	float respawnTimer = 0f;
	float randomness;
	int spawnBrickCheck;
	GameObject brick;

	// Use this for initialization
	void Start () {
		brickPresent = true;
		brick = Instantiate (brickPrefab, transform.position, Quaternion.identity) as GameObject;
		randomness = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkForBrick ();
		spawnBrick ();
	}

	void spawnBrick(){
		if(brickPresent == false){
			if(respawnTimer >= respawnTime){
				spawnBrickCheck = (int)Random.Range (0, randomness);
				if(spawnBrickCheck == 0){
					brick = Instantiate (brickPrefab, transform.position, Quaternion.identity) as GameObject;
					randomness = 5.0f;
					brickPresent = true;
					//print ("true");
				} else {
					randomness -= 1.0f;
				}
				respawnTimer = 0.0f;
			}
			respawnTimer += Time.deltaTime;
		}
	}

	void checkForBrick(){
		if(brick == null){
			brickPresent = false;
		} else {
			brickPresent = true;
		}
	}
}
