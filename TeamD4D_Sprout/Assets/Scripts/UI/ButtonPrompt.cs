using UnityEngine;
using System.Collections;

public class ButtonPrompt : MonoBehaviour {

	public float triggerValue = 6f;
	public float fadeRate = .02f;

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

		sRender.color = fullAlpha;

		player = GameObject.FindGameObjectWithTag("Player");
		if (player != null) {
			UpdateDistance();
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDistance();
		
		if (playerDist < triggerValue) {
			FadeIn();
		}
		else {
			FadeOut();
		}
	}

	void UpdateDistance() {
		Vector3 difference = transform.position - player.transform.position;
		playerDist = difference.magnitude;
	}

	void FadeIn() {
		if (sRender.color.a < 1) {
			sRender.color = Color.Lerp(sRender.color, originalColor, fadeRate);
		}
	}

	void FadeOut() {
		if (sRender.color.a > 0) {
			sRender.color = Color.Lerp(sRender.color, fullAlpha, fadeRate);
		}
	}
}
