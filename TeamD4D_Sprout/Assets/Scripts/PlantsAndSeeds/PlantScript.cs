using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {

	public bool golden = false;
	public float animationTime = 2f;

	// Use this for initialization
	void Start () {
		if (golden) {

			var animator = GetComponent<Animator>();

			if (!animator)
				animator = GetComponentInChildren<Animator>();
					if (!animator)
						Invoke("BroadcastGrown", 1f);
			else
				Invoke("BroadcastGrown", animationTime);
		}

		var region = GetComponentInParent<RegionVitalityManager>();

		if (region) {
			if (region.Living) {
				Invoke("EnableLifeCycle", animationTime);
			}
		}
	}

	void BroadcastGrown() {
		SendMessageUpwards("GoldenSeedGrown");
	}

	void EnableLifeCycle() {
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
