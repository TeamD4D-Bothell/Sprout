/*
	Connor McGwire - June 2016
	Post "release" experiment that didn't pan out initially
 */

using UnityEngine;
using System.Collections;

public class CinematicCamera : StateMachineBehaviour {

	private CinematicCameraTrigger trigger;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		trigger = animator.gameObject.GetComponentInParent<CinematicCameraTrigger>();
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(trigger) {
			trigger.Exit();
		}
		else {
			Debug.LogError("That didn't work");
		}
	}
}
