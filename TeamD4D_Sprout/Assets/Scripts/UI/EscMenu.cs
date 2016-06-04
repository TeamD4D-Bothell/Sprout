using UnityEngine;
using System.Collections;

public class EscMenu : MonoBehaviour {

	private GameObject menu;
	private float initialTimeScale;
	
	void Awake() {
		var menuRect = GetComponentInChildren<RectTransform>(true);
		menu = menuRect.gameObject;
		menu.SetActive(false);
		initialTimeScale = Time.timeScale;
	}

	// Update is called once per frame
	void Update () {
		if(menu.activeInHierarchy) {
			if (Input.GetButtonDown("Cancel")) {
				menu.SetActive(false);
				Time.timeScale = initialTimeScale;
			}
		}
		else {
			if (Input.GetButtonDown("Cancel")) {
				menu.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}
}
