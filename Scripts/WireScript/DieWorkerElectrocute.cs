using UnityEngine;
using System.Collections;

public class DieWorkerElectrocute: MonoBehaviour {

	// Use this for initialization
	void Start () {
		StaticAudio.HitPlankFalling();
		Destroy(gameObject,1.4f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
