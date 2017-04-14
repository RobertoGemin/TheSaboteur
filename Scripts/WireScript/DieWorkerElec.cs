using UnityEngine;
using System.Collections;

public class DieWorkerElec : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StaticAudio.HitPlankFalling();
		Destroy(gameObject,1.2f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
