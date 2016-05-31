using UnityEngine;
using System.Collections;
using System;

public class CameraLogic : MonoBehaviour {

	public float yOffset = 2f;
	public float xPush = 3f;
	public float yPush = 2f;
	[Range(1f, 10f)]
	public float snappiness = 1f;

	private Bounds cameraBounds;
	private GameObject player;

	void Start() {
		GameObject boundsQuad = GameObject.Find("CameraBounds");
		BoxCollider2D boundsCollider = boundsQuad.GetComponent<BoxCollider2D>();
		cameraBounds = boundsCollider.bounds;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	void LateUpdate() {
		MoveCamera();
		ClampToBounds();
	}

	private void ClampToBounds() {
		Vector3 clampedPosition = transform.position;

		if (transform.position.x < cameraBounds.min.x) {
			clampedPosition.x = cameraBounds.min.x;
		}
		else if (transform.position.x > cameraBounds.max.x) {
			clampedPosition.x = cameraBounds.max.x;
		}

		if (transform.position.y < cameraBounds.min.y) {
			clampedPosition.y = cameraBounds.min.y;
		}
		else if (transform.position.y > cameraBounds.max.y) {
			clampedPosition.y = cameraBounds.min.y;
		}

		transform.position = clampedPosition;
	}

	private void MoveCamera() {
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x;
		newPosition.y = player.transform.position.y + yOffset;

		Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal") * xPush, 
										Input.GetAxis("Vertical") * yPush);

		newPosition += inputVector;

		transform.position = Vector3.Lerp(transform.position, newPosition, snappiness * Time.deltaTime);
	}
}
