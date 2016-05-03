﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rb;
	private PlayerMovement playerMovement;

	public string AnimStateParam = "State", 
		AnimWalkSpeedParam = "WalkSpeed", 
		AnimFaceRightParam = "FaceRight";

	private int AnimStateKey, 
		AnimWalkSpeedKey, 
		AnimFaceRightKey;

	void Awake() {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		playerMovement = GetComponent<PlayerMovement>();

		AnimStateKey = Animator.StringToHash(AnimStateParam);
		AnimWalkSpeedKey = Animator.StringToHash(AnimWalkSpeedParam);
		AnimFaceRightKey = Animator.StringToHash(AnimFaceRightParam);
	}

	void Update() {
		Debug.Log(playerMovement.isGrounded);
		if (playerMovement.isGrounded) {
			if (rb.velocity.x != 0f) {
				SetState(1);
				SetDirection();
				SetWalkSpeed();
			}
			else {
				SetState(0);
			}
		}
		else {
			SetState(2);
		}
	}

	private void SetState(int state) {
		animator.SetInteger(AnimStateKey, state);
	}

	private void SetWalkSpeed() {
		animator.SetFloat(AnimWalkSpeedKey, rb.velocity.x);
	}

	private void SetDirection() {
		if (rb.velocity.x > 0) {
			animator.SetBool(AnimFaceRightKey, true);
			transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
		}
		else if (rb.velocity.x < 0) {
			animator.SetBool(AnimFaceRightKey, false);
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		}
	}
}
