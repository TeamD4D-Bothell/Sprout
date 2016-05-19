using UnityEngine;
using System.Collections;

public class RegionVitalityManager : MonoBehaviour {

	private int goldenPlantsNeeded;

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
		worldManager = managerObject.GetComponent<WorldVitalityManager>();

		var plantingSpots = GetComponentsInChildren<PlantingSpot>();
		foreach (PlantingSpot plantingSpot in plantingSpots) {
			if (plantingSpot.golden) {
				goldenPlantsNeeded++;
			}
		}

		Debug.Log(gameObject.name + ": " + goldenPlantsNeeded);
	}
	
	public void setAlive(bool val) {
		region = GetComponentsInChildren<LifeCycle>();

		if (region != null) {
			foreach (LifeCycle script in region) {
				script.living = val;
			}

			if (val) {
				worldManager.AddCured();
			}
			else {
				worldManager.SubtractCured();
			}
		}
	}

	public void GoldenSeedGrown() {
		goldenPlants++;
		if (goldenPlants >= goldenPlantsNeeded) {
			Living = true;
		}
	}
}
