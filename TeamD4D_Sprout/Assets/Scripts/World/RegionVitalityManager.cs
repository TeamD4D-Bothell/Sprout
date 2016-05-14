using UnityEngine;
using System.Collections;

public class RegionVitalityManager : MonoBehaviour {

	public int GoldenPlantsNeeded;
	private int goldenPlants;

	private bool living;
	private LifeCycle[] region;
	private PlantingSpot[] plantingSpots;

	public bool debug = false;
	public bool Living {
		get { return living; }
		set {
			living = value;
			setAlive(value);
		}
	}
	
	public void setAlive(bool val) {
		region = GetComponentsInChildren<LifeCycle>();
		foreach (LifeCycle script in region) {
			script.living = val;
		}
	}

	public void GoldenSeedGrown() {
		goldenPlants++;
		if (goldenPlants >= GoldenPlantsNeeded) {
			Living = true;
		}
	}
}
