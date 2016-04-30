using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public string horizInputString = "Horizontal";
	public string jumpKey = "Jump";
	public float speed = 5f;
	public float maxJumpHeight = 4f;

	private Rigidbody2D rb2D;
	private GroundChecker groundChecker;

	public string animStateKey, animWalkSpeedKey, animDirectionKey;
	private int animState, animWalkSpeed, animDirection;
	private Animator animator;
	
	/****************************************************************************/

	void Awake () {
		rb2D = GetComponent<Rigidbody2D>();
		groundChecker = GetComponentInChildren<GroundChecker>();
		animator = GetComponent<Animator>();
		animState = Animator.StringToHash(animStateKey);
		animWalkSpeed = Animator.StringToHash(animWalkSpeedKey);
		animDirection = Animator.StringToHash(animDirectionKey);
	}
	
	void Update () {
		float inputVal = Input.GetAxis(horizInputString);
		
		Move(inputVal);

		if (Input.GetButtonDown(jumpKey) && groundChecker.isGrounded) {
			Jump(maxJumpHeight);
		}
	}

	/****************************************************************************/

	
	public void Move(float input) {
		if (input != 0) {
			SetAnimationState(1);
			SetWalkSpeed(Mathf.Abs(input));
			if (input > 0) {
				SetAnimationDirection(true);
				transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
			}
			else if (input < 0) {
				SetAnimationDirection(false);
				transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
			}

			transform.Translate(Vector3.right * speed * Time.deltaTime * input,
								Space.World);
		}
		else
			SetAnimationState(0);
	}

	public void Jump(float scale) {
		rb2D.AddForce(Vector3.up * scale, ForceMode2D.Impulse);
	}

	public void SetAnimationState(int state) {
		animator.SetInteger(animState, state);
	}

	public void SetWalkSpeed(float speed) {
		animator.SetFloat(animWalkSpeed, speed);
	}

	public void SetAnimationDirection(bool direction) {
		animator.SetBool(animDirection, direction);
	}
}
