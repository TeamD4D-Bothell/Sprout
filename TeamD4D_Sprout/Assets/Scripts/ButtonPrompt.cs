using UnityEngine;
using System.Collections;

public class ButtonPrompt : MonoBehaviour {

	public string button = "UNASSIGNED";
	public KeyCode key;
	public float triggerValue = 6f;
	public float fadeRate = .1f;

	private SpriteRenderer sRender;
	private GameObject player;
	private float playerDist = 100f;
	private bool buttonClicked = false;

	private Color originalColor, fullAlpha;

	// Use this for initialization
	void Start () {
		sRender = GetComponent<SpriteRenderer>();
		originalColor = sRender.color;
		fullAlpha = sRender.color;
		fullAlpha.a = 0;

		player = GameObject.FindGameObjectWithTag("Player");
		if (player != null) {
			UpdateDistance();
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDistance();

		if (!buttonClicked) {
			if (playerDist < triggerValue) {
				CheckButtonClicked();
				FadeIn();
			}
			else {
				FadeOut();
			}
		}
	}

	void CheckButtonClicked() {
		if (Input.GetButtonUp(button) || Input.GetKeyUp(key)) {
			buttonClicked = true;
			gameObject.SetActive(false);
		}
	}

	void UpdateDistance() {
		Vector3 difference = transform.position - player.transform.position;
		playerDist = difference.magnitude;
	}

	void FadeIn() {
		if (sRender.color.a < 255) {
			sRender.color = Color.Lerp(sRender.color, originalColor, fadeRate);
		}
	}

	void FadeOut() {
		if (sRender.color.a > 0) {
			sRender.color = Color.Lerp(sRender.color, fullAlpha, fadeRate);
		}
	}
}
