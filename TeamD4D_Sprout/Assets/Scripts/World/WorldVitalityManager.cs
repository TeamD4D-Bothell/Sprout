using UnityEngine;
using System.Collections;

public class WorldVitalityManager : MonoBehaviour {

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

	void Update() {
		if (debug) {
			if (Input.GetKeyDown(KeyCode.Alpha1))
				setAlive(true);
			else if (Input.GetKeyDown(KeyCode.Alpha2))
				setAlive(false);
		}
	}
	
	public void setAlive(bool val) {
		region = GetComponentsInChildren<LifeCycle>();
		foreach (LifeCycle script in region) {
			script.living = val;
		}
	}
}
