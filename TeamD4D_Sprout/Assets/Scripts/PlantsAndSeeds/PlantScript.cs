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
	}

	void BroadcastGrown() {
		SendMessageUpwards("GoldenSeedGrown");
	}
}
