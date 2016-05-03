using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour {

	public float jumpHeight = 5;
	public float moveSpeed = 5;
	public float maxClimbAngle = 60f;

	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;

	public float raycastSkin = 0.12f;
	public float raycastLength = 0.15f;
	LayerMask layerToIgnore;
	private Vector2 raycastOrigin;
	private bool grounded = false;

	public bool isGrounded { get { return grounded; } }

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
		Move(hVal);
	}

	void Update() {
		bool jumping = Input.GetButtonDown("Jump");

		if (jumping && grounded) {
			Debug.Log("Jumping");
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
		}
	}

	void Move(float input) {
		// Adjust for slope angle
		UpdateRaycastOrigin();
		RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastLength, layerToIgnore);

		if (hit) {
			// Move
			grounded = true;
			var slopeRatio = CalculateSlopeRatio(hit.normal);
			float scaledInput = input * moveSpeed * slopeRatio;

			rb.velocity = new Vector2(scaledInput, rb.velocity.y);
		}
		else {
			grounded = false;
		}
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
}
