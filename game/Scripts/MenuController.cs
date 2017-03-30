using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Dropdown DropDownMenu;
	private string APIURL = "https://treasure-hunt-api.herokuapp.com/menu";
	private double Longitude;
	private double Latitude;

	void Start () {
		StartUpGPS ();
		ReadMenuData ();

		DropDownMenu.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(DropDownMenu);
		});	
	}

	void ReadMenuData () {
		var url = APIURL + "?Longitude=" + Longitude.ToString () + "&Latitude=" + Latitude.ToString ();
		string[] data = JsonObjectParser.GetJsonObject (url);
		for (int i = 0; i < data.Length; i ++) {
			DropDownMenu.options.Add (new Dropdown.OptionData (data[i]));
		}
	}

	void Destroy() {
		DropDownMenu.onValueChanged.RemoveAllListeners();
	}

	private void myDropdownValueChangedHandler(Dropdown target) {
		PlayerPrefs.SetInt("InitialTreasureHuntID", DropDownMenu.value);
		Application.LoadLevel("GameView");
	}

	private void StartUpGPS () {
		GPSScript.StartGPS ();
		double[] gps = GPSScript.UpdateGPS ();
		Longitude = gps [0];
		Latitude = gps [1];
	}
}
