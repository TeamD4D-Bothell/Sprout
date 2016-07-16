using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/RegionScripts/World Vitality Manager")]
public class WorldVitalityManager : MonoBehaviour {

	private int totalRegions = 0;
	public int TotalRegions { get { return totalRegions; } }

	private int curedRegions = 0;
	public float PercentCured { get { return curedRegions / totalRegions; } }

	private LifeCycle[] backgroundImages;

	void Start() {
		GameObject[] regions = GameObject.FindGameObjectsWithTag("Region");
		totalRegions = regions.Length;

		backgroundImages = GetComponentsInChildren<LifeCycle>();
	}

	public void AddCured() {
		curedRegions++;
		UpdateBackground();
	}

	public void SubtractCured() {
		curedRegions--;
		UpdateBackground();
	}

	private void UpdateBackground() {
		if (backgroundImages != null) {
			foreach (LifeCycle image in backgroundImages) {
				image.setAlive();
			}
		}
		else {
			Debug.Log("No lifeCycle scripts attached to WorldVitalityManager");
		}
	}
}
