using UnityEngine;
using System.Collections;

public class RegionVitalityManager : MonoBehaviour {

	public int GoldenPlantsNeeded;

	private int goldenPlants;
	private bool living;
	private LifeCycle[] region;
	private PlantingSpot[] plantingSpots;

	private WorldVitalityManager worldManager;

	public bool Living {
		get { return living; }
		set {
			living = value;
			setAlive(value);
		}
	}

	void Start() {
		var managerObject = GameObject.FindGameObjectWithTag("WorldManager");
		if (managerObject)
			worldManager = managerObject.GetComponent<WorldVitalityManager>();
	}
	
	public void setAlive(bool val) {
		region = GetComponentsInChildren<LifeCycle>();
		foreach (LifeCycle script in region) {
			script.living = val;
		}

		if (val) {
			if (worldManager)
				worldManager.AddCured();
		}
		else {
			if (worldManager)
				worldManager.SubtractCured();
		}
	}

	public void GoldenSeedGrown() {
		goldenPlants++;
		if (goldenPlants >= GoldenPlantsNeeded) {
			Living = true;
		}
	}
}
