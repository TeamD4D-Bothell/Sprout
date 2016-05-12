using UnityEngine;
using System.Collections;

public class CloseGame : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
