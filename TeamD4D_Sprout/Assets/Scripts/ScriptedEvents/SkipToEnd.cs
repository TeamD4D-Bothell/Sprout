/*
	Connor McGwire - May 2016
	Debug button for play testing
 */

using UnityEngine;
using System.Collections;

public class SkipToEnd : MonoBehaviour {

	public Vector3 skipPos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void Skip() {
		player.transform.position = skipPos;
	}
}
