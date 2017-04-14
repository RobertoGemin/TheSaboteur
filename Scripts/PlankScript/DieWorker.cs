using UnityEngine;
using System.Collections;

public class DieWorker : MonoBehaviour {


	
	
	
	// Use this for initialization
	void Start () {
		
		StaticAudio.Hithead();
		
		Destroy(gameObject,0.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
