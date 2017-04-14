using UnityEngine;
using System.Collections;

public class showScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = "" + StaticScore.workersKilled;
		print ("" + StaticScore.workersKilled);
		guiText.pixelOffset = new Vector2 (Screen.width / 2, (Screen.height / 20) * 13.9f);
	}
	
	// Update is called once per frame
	void Update () {
	

	
		
	}
}
