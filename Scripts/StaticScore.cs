using UnityEngine;
using System.Collections;

public class StaticScore : MonoBehaviour {

	public static int workersKilled;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
