using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour 
{
	
	
	public  TextMesh killtext;
	public  TextMesh progresstext;
	public static int floorCount = 1;
	public static int maxFloor = 1;
	
	public static int WorkerCountTotal = 1;
	public static int WorkerCount = 0;
	public static int WorkerKilled = 0;
	public static int workersOnFloor1 = 0;
	public static int workersOnFloor2 = 0;
	public static int workersOnFloor3 = 0;
	public static int workersOnFloor4 = 0;
	public static int workersOnFloor5 = 0;

	// Use this for initialization

	
	public static void AddWorker()
    {
		WorkerCountTotal ++;
		WorkerCount ++;
    }
	
	public static void KillWorker()
    {
		
		WorkerCount --;
		WorkerKilled++;
       //print ("worker count " + WorkerCount + " total count" +WorkerCountTotal );
	
    }

	void Awake(){
		workersOnFloor1 = 0;
		workersOnFloor2 = 0;
		workersOnFloor3 = 0;
		workersOnFloor4 = 0;
		workersOnFloor5 = 0;
	}

	void Update () {
		print (WorkerCount);
	}
}
