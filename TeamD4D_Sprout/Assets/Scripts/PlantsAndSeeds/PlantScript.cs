using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/PlantScripts/Plant Script")]
public class PlantScript : MonoBehaviour {
	// Whether or not plant contributes to region revival
	public bool golden = false;
	// Time until revive if no animation is present
	public float animationTime = 1.5f;

	private bool grown = false;
	private RegionVitalityManager region;

	// Use this for initialization
	void Start () {
		region = GetComponentInParent<RegionVitalityManager>();

		// If golden, wait some time to signal
		if (golden) {
			// Find Animator component; May be in child
			// Animator controls timing by default
			var animator = GetComponentInChildren<Animator>();
			
			// If Animator doesn't exist, invoke on manual animation time
			if (!animator) {
				Invoke("SignalGrown", animationTime);
			}
		}
	}

	// Tell the region manager that the plant has been grown
	public void SignalGrown() {
		if (!grown) {
			if (golden) {
				region.GoldenSeedGrown();
			}
			CheckRegionLiving();
			grown = true;
		}
	}

	// Called on growth to check if region is already alive
	public void CheckRegionLiving() {
		// Finds all "LifeCycle" components attached to this plant
		// Then sets them to living
		var lifeCycles = GetComponentsInChildren<LifeCycle>();
		if (lifeCycles.Length > 0 && region.Living) {
			foreach (LifeCycle lifeCycle in lifeCycles) {
				lifeCycle.setAlive();
			}
		}
	}
}
