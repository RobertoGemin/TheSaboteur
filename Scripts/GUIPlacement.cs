using UnityEngine;
using System.Collections;

public class GUIPlacement : MonoBehaviour {

	public GUITexture muteButPrefab;
	public GUITexture scorePrefab;
	public GUITexture playButPrefab;
	public GUIText scoreTextPrefab;
	GUITexture muteButton;
	GUITexture scoreButton;
	GUITexture playButton;
	public GUITexture percBubble1;
	public GUITexture percBubble2;
	public GUITexture percBubble3;
	public GUITexture percBubble4;
	public GUITexture percBubble5;
	public GUIText bubbleText1;
	public GUIText bubbleText2;
	public GUIText bubbleText3;
	public GUIText bubbleText4;
	public GUIText bubbleText5;
	GUIText scoreText;
	Vector3 scoreTextPosition = new Vector3(0,0,0.05f);


	// Use this for initialization
	void Start () {
		float GUIyPos = (Screen.height / 20) * 18.8f;
		float MutexPos = (Screen.width / 20) * 17.2f;
		float ScorexPos = (Screen.width / 20) * 6.7f;
		float PlayxPos = (Screen.width / 20) * 0.5f;
		float ScoreTextxPos = (Screen.width / 20) * 12.4f;
		float percBubblesxPos = (Screen.width / 20) * 1.30f;
		Rect muteButRect = new Rect (MutexPos, GUIyPos, 66, 45);
		Rect scoreRect = new Rect (ScorexPos, GUIyPos, 211, 45);
		Rect playButRect = new Rect (PlayxPos, GUIyPos, 66, 45);
		Vector2 tmpVec2 = new Vector2(ScoreTextxPos, (GUIyPos +24));
		muteButton = Instantiate (muteButPrefab, Vector3.zero, Quaternion.identity) as GUITexture;
		muteButton.pixelInset = muteButRect;
		scoreButton = Instantiate (scorePrefab, Vector3.zero, Quaternion.identity) as GUITexture;
		scoreButton.pixelInset = scoreRect;
		playButton = Instantiate (playButPrefab, Vector3.zero, Quaternion.identity) as GUITexture;
		playButton.pixelInset = playButRect;
		scoreText = Instantiate (scoreTextPrefab, scoreTextPosition, Quaternion.identity) as GUIText;
		scoreText.pixelOffset = tmpVec2;
		percBubble1.pixelInset = new Rect (percBubblesxPos, 50, 100, 100);
		percBubble2.pixelInset = new Rect (percBubblesxPos, 210, 100, 100);
		percBubble3.pixelInset = new Rect (percBubblesxPos, 370, 100, 100);
		percBubble4.pixelInset = new Rect (percBubblesxPos, 530, 100, 100);
		percBubble5.pixelInset = new Rect (percBubblesxPos, 690, 100, 100);
		bubbleText1.pixelOffset = new Vector2(90,100);
		bubbleText2.pixelOffset = new Vector2(90,260);
		bubbleText3.pixelOffset = new Vector2(90,420);
		bubbleText4.pixelOffset = new Vector2(90,580);
		bubbleText5.pixelOffset = new Vector2(90,740);
		percBubble1.gameObject.SetActive (false);
		percBubble2.gameObject.SetActive (false);
		percBubble3.gameObject.SetActive (false);
		percBubble4.gameObject.SetActive (false);
		percBubble5.gameObject.SetActive (false);
		bubbleText1.gameObject.SetActive (false);
		bubbleText2.gameObject.SetActive (false);
		bubbleText3.gameObject.SetActive (false);
		bubbleText4.gameObject.SetActive (false);
		bubbleText5.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		placeProgressGUI();
		handleProgress ();
	}

	void placeProgressGUI(){
		if(gameObject.GetComponent<Spawnfloors>().floorList.Count == 1){
			percBubble1.gameObject.SetActive (true);
			bubbleText1.gameObject.SetActive (true);
		} else if(gameObject.GetComponent<Spawnfloors>().floorList.Count == 2){
			percBubble2.gameObject.SetActive (true);
			bubbleText2.gameObject.SetActive (true);
		} else if(gameObject.GetComponent<Spawnfloors>().floorList.Count == 3){
			percBubble3.gameObject.SetActive (true);
			bubbleText3.gameObject.SetActive (true);
		} else if(gameObject.GetComponent<Spawnfloors>().floorList.Count == 4){
			percBubble4.gameObject.SetActive (true);
			bubbleText4.gameObject.SetActive (true);
		} else if(gameObject.GetComponent<Spawnfloors>().floorList.Count == 5){
			percBubble5.gameObject.SetActive (true);
			bubbleText5.gameObject.SetActive (true);
		}
	}

	void handleProgress() {
		if(percBubble1.gameObject.activeSelf == true && bubbleText1.gameObject.activeSelf == true){
			bubbleText1.guiText.text = "" + (int)gameObject.GetComponent<Spawnfloors>().floorList[0].gameObject.GetComponent<FloorScript>().floorProgress + "%";
		} if (percBubble2.gameObject.activeSelf == true && bubbleText2.gameObject.activeSelf == true) {
			bubbleText2.guiText.text = "" + (int)gameObject.GetComponent<Spawnfloors>().floorList[1].gameObject.GetComponent<FloorScript>().floorProgress + "%";
		} if (percBubble3.gameObject.activeSelf == true && bubbleText3.gameObject.activeSelf == true) {
			bubbleText3.guiText.text = "" + (int)gameObject.GetComponent<Spawnfloors>().floorList[2].gameObject.GetComponent<FloorScript>().floorProgress + "%";
		} if (percBubble4.gameObject.activeSelf == true && bubbleText4.gameObject.activeSelf == true) {
			bubbleText4.guiText.text = "" + (int)gameObject.GetComponent<Spawnfloors>().floorList[3].gameObject.GetComponent<FloorScript>().floorProgress + "%";
		} if (percBubble5.gameObject.activeSelf == true && bubbleText5.gameObject.activeSelf == true) {
			bubbleText5.guiText.text = "" + (int)gameObject.GetComponent<Spawnfloors>().floorList[4].gameObject.GetComponent<FloorScript>().floorProgress + "%";
		}
	}
}
