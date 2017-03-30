using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;

public class POIChecker : MonoBehaviour {

	public static double DistanceAway(double GPSLongitude, double GPSLatitude, double ClueLongitude, double ClueLatitude){
		var baseRad = Math.PI * GPSLatitude / 180;
		var targetRad = Math.PI * ClueLatitude / 180;
		var theta = GPSLongitude - ClueLongitude;
		var thetaRad = Math.PI * theta / 180;

		double distance =
			Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
			Math.Cos(targetRad) * Math.Cos(thetaRad);
		distance = Math.Acos(distance);

		distance = distance * 180 / Math.PI;
		distance = distance * 60 * 1.1515;
		distance = distance * 1.609344;

		return distance;
	}
}