using UnityEngine;
using System.Collections;

public class AnimatedTree : MonoBehaviour {

	[Range(0.01f, 1f)]
	public float climbStartRatio = 0.3f;

	private BoxCollider2D box;
	private Animator animator;
	private PlantScript plantScript;

	// Use this for initialization
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
