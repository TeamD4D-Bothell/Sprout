using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {

	public bool golden = false;

	// Use this for initialization
	void Start ()
    {
		if (golden) {
			Debug.Log("GOLDEN PLANT GROWN");
			Invoke("BroadcastGrown", 1f);
		}

		var region = GetComponentInParent<RegionVitalityManager>();

		if (region) {
			if (region.Living) {
				var lifeCycle = GetComponent<LifeCycle>();
				if (lifeCycle) {
					lifeCycle.living = true;
				}

				var childLifeCycles = GetComponentsInChildren<LifeCycle>();
				if (childLifeCycles.Length > 0) {
					foreach (LifeCycle lifecycle in childLifeCycles) {
						lifecycle.living = true;
					}
				}
			}
		}
	}

	void BroadcastGrown() {
		SendMessageUpwards("GoldenSeedGrown");
	}
}
