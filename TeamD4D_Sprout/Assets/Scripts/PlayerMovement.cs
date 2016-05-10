using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour {

	public float jumpHeight = 5f;
	public float moveSpeed = 5f;
	public float maxClimbAngle = 60f;
	public float climbSpeed = 3f;

	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;

	private float slopeRatio = 1f;

	public float raycastSkin = 0.12f;
	public float raycastLength = 0.15f;
	LayerMask layerToIgnore;
	private Vector2 raycastOrigin;
	private bool grounded = false;
	private bool canClimb = false;

	public bool isGrounded { get { return grounded; } }
	public bool isClimbing { get { return canClimb; } }

	/***************************************************/

	void Awake() {
		// Initialize necessary components
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		layerToIgnore = LayerMask.GetMask("Environment");
		UpdateRaycastOrigin();
	}
	
	void FixedUpdate() {
		// Get input
		float hVal = Input.GetAxis("Horizontal");
		CheckGrounded();

		if (grounded || canClimb) {
			Move(hVal);
		}

		if (canClimb && rb.velocity.y <= climbSpeed) {
			Climb();
		}
	}

	void Update() {
		bool jumping = Input.GetButtonDown("Jump");

		if (jumping && (grounded || canClimb)) {
			Jump();
		}
	}

	/***************************************************/

	void CheckGrounded() {
		// Adjust for slope angle
		UpdateRaycastOrigin();
		RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastLength, layerToIgnore);

		if (hit) {
			grounded = true;
			slopeRatio = CalculateSlopeRatio(hit.normal);
		}
		else grounded = false;
	}

	void Move(float input) {
		float scaledInput = input * moveSpeed * slopeRatio;
		rb.velocity = new Vector2(scaledInput, rb.velocity.y);
	}

	void UpdateRaycastOrigin() {
		raycastOrigin = new Vector2((boxCollider.bounds.min.x + boxCollider.bounds.max.x) / 2,
									boxCollider.bounds.min.y - raycastSkin);
	}

	// Might not need this, but keeping it regardless.
	Vector2 CalculateTangentNormal(Vector2 normal, float input) {
		return Vector3.Normalize(input * (Vector3.Cross(normal, Vector3.forward)));
	}

	float CalculateSlopeRatio(Vector2 normal) {
		float adjustedAngle = 90 - (Vector2.Angle(Vector2.up, normal));
		return  adjustedAngle / 90f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Climbable") {
			canClimb = true;

		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Climbable") {
			canClimb = false;
		}
	}

	void Jump() {
		rb.velocity = new Vector2(rb.velocity.x, 0);
		rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
	}

	void Climb() {
		var input = Input.GetAxis("Vertical");

		if (rb.velocity.y < 0) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
		}

		if (input != 0) {
			float scaledInput = input * climbSpeed;
			rb.velocity = new Vector2(rb.velocity.x, scaledInput);
		}
	}
}
