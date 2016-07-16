using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Sprout/RegionScripts/Region Vitality Manager")]
public class RegionVitalityManager : MonoBehaviour {

	// Event to tell other Unity objects when the region has revived
	public UnityEvent onRegionRevive;

	private int goldenPlantsNeeded;
	private int goldenPlants;
	private bool living;

	public bool Living {
		get { return living; }
	}

	private WorldVitalityManager worldManager;

	void Start() {
		// Find the world manager
		var managerObject = GameObject.FindGameObjectWithTag("WorldManager");
		if (managerObject) {
			worldManager = managerObject.GetComponent<WorldVitalityManager>();
		}
		else {
			Debug.Log("No WorldManager object");
		}

		// Count the number of golden planting spots in the region
		var plantingSpots = GetComponentsInChildren<PlantingSpot>();
		foreach (PlantingSpot plantingSpot in plantingSpots) {
			if (plantingSpot.golden) {
				goldenPlantsNeeded++;
			}
		}
	}
	
	// Sets region to a living state;
	public void setAlive() {
		onRegionRevive.Invoke();
		living = true;
		
		if(worldManager) {
			worldManager.AddCured();
		}
	}

	// Add to count of grown, golden plants;
	// Initiate revival if count maximum reached
	public void GoldenSeedGrown() {
		if (!living) {
			goldenPlants++;
			if (goldenPlants >= goldenPlantsNeeded) {
				setAlive();
			}
		}
	}
}
