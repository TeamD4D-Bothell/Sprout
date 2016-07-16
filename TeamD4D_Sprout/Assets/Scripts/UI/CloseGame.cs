using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/UI/Close Game")]
public class CloseGame : MonoBehaviour {
	
	public void Quit () {
		Application.Quit();
	}
}
