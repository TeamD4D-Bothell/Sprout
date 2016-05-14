using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoadButton : MonoBehaviour {

	public string LevelToLoad = "EMPTY";
	
	public void LoadLevel() {
		SceneManager.LoadScene(LevelToLoad);
	}
}
