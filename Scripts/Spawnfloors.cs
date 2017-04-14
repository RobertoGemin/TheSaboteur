using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawnfloors : MonoBehaviour {
	
	public static int ProgressLevel = 0;
	
	public  int maximumFloorCount = 5;
	public GameObject floorPrefab;
	public GameObject floor1Prefab;
	public GameObject floorRightPrefab;
	float floorDistance = 1.6425f;
	public List<GameObject> floorList = new List<GameObject>();
	Vector3 floor1Position = new Vector3(0, 0.57f, 0);
	Vector3 nextFloorPosition = Vector3.zero;
	public GameObject ladder1;
	public GameObject ladder2;
	public GameObject ladder3;
	public GameObject ladder4;
	public List<GameObject> firstFloorBricks = new List<GameObject>();
	public List<GameObject> secondFloorBricks = new List<GameObject>();
	public List<GameObject> thirdFloorBricks = new List<GameObject>();
	public List<GameObject> fourthFloorBricks = new List<GameObject>();
	public List<GameObject> fifthFloorBricks = new List<GameObject>();
	public bool firstFloor = false;
	public bool secondFloor = false;
	public bool thirdFloor = false;
	public bool fourthFloor = false;
	public bool fifthFloor = false;
	int floorID;

	// Use this for initialization
	void Start () {
		
		LevelController.maxFloor = maximumFloorCount;
		GameObject floor1 = Instantiate (floor1Prefab, floor1Position, Quaternion.identity) as GameObject;
		floorList.Add (floor1);
		floor1.gameObject.GetComponent<FloorScript> ().floorID = 1;
		floorID = 1;
		nextFloorPosition = floor1Position;
	}
	
	// Update is called once per frame
	void Update () {
		StaticScore.workersKilled = LevelController.WorkerKilled;
	}

	public void AddFloor(){
		nextFloorPosition.y += floorDistance;
		nextFloorPosition.z += -0.00001f;
		floorID += 1;
		if(floorID == 2){
			GameObject floor = Instantiate (floorRightPrefab, nextFloorPosition, Quaternion.identity) as GameObject;
			floorList.Add (floor);
			FloorScript sc = floor.gameObject.GetComponent<FloorScript> ();
			sc.floorID = floorList.Count;
			LevelController.floorCount = floorList.Count;
		} else if ( floorID == 3){
			GameObject floor = Instantiate (floorPrefab, nextFloorPosition, Quaternion.identity) as GameObject;
			floorList.Add (floor);
			FloorScript sc = floor.gameObject.GetComponent<FloorScript> ();
			sc.floorID = floorList.Count;
			LevelController.floorCount = floorList.Count;
		} else if ( floorID == 4){
			GameObject floor = Instantiate (floorRightPrefab, nextFloorPosition, Quaternion.identity) as GameObject;
			floorList.Add (floor);
			FloorScript sc = floor.gameObject.GetComponent<FloorScript> ();
			sc.floorID = floorList.Count;
			LevelController.floorCount = floorList.Count;
		} else if ( floorID == 5){
			GameObject floor = Instantiate (floorPrefab, nextFloorPosition, Quaternion.identity) as GameObject;
			floorList.Add (floor);
			FloorScript sc = floor.gameObject.GetComponent<FloorScript> ();
			sc.floorID = floorList.Count;
			LevelController.floorCount = floorList.Count;
		}
	}

	void checkLevelProgress(){

	}
}
