using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using UnityEngine;

public class JsonObjectParser : MonoBehaviour {
	public static string[] GetJsonObject (string url){
		string[] data;
		using (WebClient wc = new WebClient())
		{
			var json = wc.DownloadString(url);
			json = json.ToString ();
			data = json.Split (':');
		}
		return data;
	}
}