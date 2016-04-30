using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	public string groundTag = "Ground";
	private bool grounded = false;
	public bool isGrounded { get { return grounded; } }

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Ground"))
			grounded = true;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag("Ground"))
			grounded = false;
	}
}
