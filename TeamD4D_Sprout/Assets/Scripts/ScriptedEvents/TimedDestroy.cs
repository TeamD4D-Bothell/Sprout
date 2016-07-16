using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/Events/Timed Destroy")]
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
