using UnityEngine;
using System.Collections;

// TODO: REPLACE WITH GENERIC ANIMATED PLANT SCRIPT
public class AnimatedTree : MonoBehaviour {
	// Variable for controlling when the player can start climbing
	// the animated object
	[Range(0.01f, 1f)]
	public float climbStartRatio = 0.3f;

	private BoxCollider2D box;
	private Animator animator;
	private PlantScript plantScript;

	void Start () {
		box = GetComponent<BoxCollider2D>();
		animator = GetComponentInChildren<Animator>();

		box.enabled = false;
		
		var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		Invoke("EnableClimb", stateInfo.length * climbStartRatio);
	}
	
	void EnableClimb() {
		box.enabled = true;
	}
}
