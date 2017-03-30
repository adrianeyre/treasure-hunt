using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System;

public class Main : MonoBehaviour {

	public Text ClueText;
	public Text DistanceText;
	public Text GPSText;
	public Image ClueImage;
	public GameObject Goal;
	public Text NextClue;

	private double ClueLongitude;
	private double ClueLatitude;
	private string ClueTextData;
	private int TreasureHuntID;
	private int ClueID;
	private IEnumerator coroutine;

	private string APIURL = "https://treasure-hunt-api.herokuapp.com/set";
	private string ImageURL = "https://treasure-hunt-api.herokuapp.com/image/";

	void Start () {
		Initialize ();
		SetClueText ();
		GPSScript.StartGPS ();
		UpdateClueImage ();
	}

	void Initialize() {
		TreasureHuntID = PlayerPrefs.GetInt("InitialTreasureHuntID");
		ClueID = 1;
	}
		
	void Update () {
		UpdateGPSData ();
	}

	void SetClueText (){
		var url = APIURL + "?TreasureHuntID=" + TreasureHuntID.ToString () + "&ClueID=" + ClueID.ToString ();
		string[] data = JsonObjectParser.GetJsonObject (url);
		ClueTextData = data[3].ToString();
		ClueText.text = "Clue " + ClueID.ToString()+ ": " + ClueTextData;
		ClueLongitude = Convert.ToDouble(data[4].ToString());
		ClueLatitude = Convert.ToDouble(data[5].ToString());
	}

	void UpdateClueImage () {
		var url = ImageURL + TreasureHuntID.ToString () + "/" + ClueID.ToString () + ".png";
		StartCoroutine (UpdateImage (url));
	}

	IEnumerator UpdateImage(string url) {
		WWW www = new WWW(url);
		yield return www;
		ClueImage.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
	}

	void UpdateGPSData () {
		double[] gps = GPSScript.UpdateGPS ();
		GPSText.text = "Long: " + gps[0].ToString ("####0.00000") + " Lat: " + gps[1].ToString ("####0.00000");

		double DistanceAway = POIChecker.DistanceAway (gps [0], gps [1], ClueLongitude, ClueLatitude);

		if (DistanceAway < 0.05) {
			Goal.GetComponent<Renderer> ().enabled = true;
			NextClue.GetComponent<Text>().enabled = true;
			DistanceText.text = "You are here!";
		} else if (DistanceAway < 0.1) {
			Goal.GetComponent<Renderer> ().enabled = false;
			NextClue.GetComponent<Text>().enabled = false;
			DistanceText.text = "Getting closer, you are approximately " + DistanceAway.ToString("####0.000") + " Km away"; 
		} else {
			Goal.GetComponent<Renderer>().enabled = false;
			NextClue.GetComponent<Text>().enabled = false;
			DistanceText.text = "You are approximately " + DistanceAway.ToString("####0.000") + " Km away";
		}
	}

	public void StartNextClue(){
		ClueID ++;
		SetClueText();
		UpdateClueImage();
		NextClue.GetComponent<Text>().enabled = false;
	}
}
