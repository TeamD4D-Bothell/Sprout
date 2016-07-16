using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/PlayerScripts/Player Animation")]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rb;
	private PlayerMovement playerMovement;

	public string AnimStateParam = "State", 
		AnimWalkSpeedParam = "WalkSpeed", 
		AnimFaceRightParam = "FaceRight",
		AnimYVelocityParam = "YVelocity";

	private int AnimStateKey, 
		AnimWalkSpeedKey, 
		AnimFaceRightKey,
		AnimYVelocityKey;

	private int pullLayer;

	void Awake() {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		playerMovement = GetComponent<PlayerMovement>();

		AnimStateKey = Animator.StringToHash(AnimStateParam);
		AnimWalkSpeedKey = Animator.StringToHash(AnimWalkSpeedParam);
		AnimFaceRightKey = Animator.StringToHash(AnimFaceRightParam);
		AnimYVelocityKey = Animator.StringToHash(AnimYVelocityParam);

		pullLayer = animator.GetLayerIndex("ArmLayer");
		animator.SetLayerWeight(pullLayer, 0f);
	}

	void Update() {
		float input = Input.GetAxis("Horizontal");
		if (playerMovement.isGrounded) {
			SetPulling();
			if (input != 0f) {
				SetState(1);
				SetWalkSpeed();
			}
			else {
				SetState(0);
			}
		}
		else {
			SetState(2);
			SetYVelocity(rb.velocity.y);
		}
		SetDirection(playerMovement.FacingLeft);
	}

	private void SetState(int state) {
		animator.SetInteger(AnimStateKey, state);
	}

	private void SetWalkSpeed() {
		animator.SetFloat(AnimWalkSpeedKey, rb.velocity.x);
	}

	private void SetDirection(bool facingLeft) {
		if (!facingLeft) {
			animator.SetBool(AnimFaceRightKey, true);
			transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
		}
		else if (facingLeft) {
			animator.SetBool(AnimFaceRightKey, false);
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		}
	}

	private void SetPulling() {
		if (playerMovement.isPulling) {
			animator.SetLayerWeight(pullLayer, 1);
		}
		else {
			animator.SetLayerWeight(pullLayer, 0);
		}
	}

	private void SetYVelocity(float velocity) {
		animator.SetFloat(AnimYVelocityKey, velocity);
	}
}
