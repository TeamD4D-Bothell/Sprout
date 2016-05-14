using UnityEngine;
using System.Collections;

public class Sprout : MonoBehaviour {

	public GameObject plantPrefab;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Water") {
			CreatePlant();
		}
	}

	void OnParticleCollision(GameObject other) {
		if (other.tag == "Water") {
			CreatePlant();
		}
	}

	void CreatePlant() {
		GameObject plant = Instantiate(plantPrefab) as GameObject;
		plant.transform.SetParent(transform.parent, true);
		plant.transform.position = transform.position;

		Destroy(this);
	}
}
