using UnityEngine;
using System.Collections;

public class StartFallStone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		foreach (Transform child in transform){
			child.gameObject.GetComponent<FallingStone>().canFall = true;
		}
	}
}
