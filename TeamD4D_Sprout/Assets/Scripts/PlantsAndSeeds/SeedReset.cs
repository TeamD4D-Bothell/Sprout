/*
	Connor McGwire - May 2016
	Seed reset mechanic. In case certain seeds are pushed out of bounds.
 */

using UnityEngine;
using System.Collections;

public class SeedReset : MonoBehaviour {
	// Optional game object with particle effect to spawn
	public GameObject resetEffect;

	private Vector3 initialPos;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Reset") {
			if (resetEffect) {
				var effect = Instantiate(resetEffect) as GameObject;
				effect.transform.position = transform.position;
			}
			transform.position = initialPos;
			if (rb) {
				rb.velocity = Vector2.zero;
				rb.angularVelocity = 0;
			}
		}
	}
}
