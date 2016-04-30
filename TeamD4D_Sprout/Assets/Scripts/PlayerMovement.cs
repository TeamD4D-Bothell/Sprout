using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public string horizInputString = "Horizontal";
	public string jumpKey = "Jump";
	public float speed = 5f;
	public float jumpHeight = 4f;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float inputVal = Input.GetAxis(horizInputString);
		if (inputVal != 0) {
			transform.Translate(Vector3.right * speed * Time.deltaTime * inputVal, 
								Space.World);
		}

		if (Input.GetButtonDown(jumpKey)) {
			rb2D.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
		}
	}
}
