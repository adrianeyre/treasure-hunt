using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;

public class GPSScript : MonoBehaviour {
	public static void StartGPS () {
		Input.location.Start (0.1f, 0.1f);
	}

	public static double[] UpdateGPS () {
		double[] result = new double[2];
		result[0] = Input.location.lastData.longitude;
		result[1] = Input.location.lastData.latitude;
		return result;
	}

	public static void StopGPS () {
		Input.location.Stop ();
	}
}