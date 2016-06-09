using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadWorld : MonoBehaviour {

	public string[] levels;
	
	void Awake () {
		foreach (var level in levels) {
			SceneManager.LoadScene(level, LoadSceneMode.Additive);
		}
	}
}
