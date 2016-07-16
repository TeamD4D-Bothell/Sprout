using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Sprout/Events/You Won")]
public class YouWon : MonoBehaviour {

	private RegionVitalityManager manager;
	private Text text;

	// Use this for initialization
	void Start () {
		manager = GetComponentInParent<RegionVitalityManager>();
		text = GetComponent<Text>();
		if (text) {
			text.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (manager) {
			if (manager.Living && !text.enabled) {
				text.enabled = true;
			}
		}
	}
}
