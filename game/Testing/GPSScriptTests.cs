using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Net;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class GPSScriptTests
{
	[Test]
	public void GPSScript_Test()
	{
		string[] data = JsonObjectParser.GetJsonObject ("https://treasure-hunt-api.herokuapp.com/set?TreasureHuntID=1&ClueID=1");
		Assert.AreEqual(data[0], "GameData");
		Assert.AreEqual(data[1], "1");
		Assert.AreEqual(data[2], "1");
	}
}