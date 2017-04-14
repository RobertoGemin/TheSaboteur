using UnityEngine;
using System.Collections;

public class ScoreChange : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "" + LevelController.WorkerKilled;
	}
}
