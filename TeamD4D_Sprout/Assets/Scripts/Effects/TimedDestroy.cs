using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

	public float timeUntilDestruction = 1f;

	// Use this for initialization
	void Start () {
		Invoke("Finido", timeUntilDestruction);
	}
	
	void Finido() {
		Destroy(gameObject);
	}
}
