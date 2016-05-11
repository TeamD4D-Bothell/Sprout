using UnityEngine;
using System.Collections;

public class WorldVitalityManager : MonoBehaviour {

	private bool living;
	private LifeCycle[] region;

	public bool debug = false;
	public bool Living {
		get { return living; }
		set {
			living = value;
			setAlive(value);
		}
	}

	// Use this for initialization
	void Start () {
		region = GetComponentsInChildren<LifeCycle>();
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
		foreach (LifeCycle script in region) {
			script.living = val;
		}
	}
}
