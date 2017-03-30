using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRotator : MonoBehaviour {

	void Start () {
		GetComponent<Renderer>().enabled = false;
	}

	void Update () {
		transform.Rotate (new Vector3 (150, 0, 0) * Time.deltaTime);
	}
}
