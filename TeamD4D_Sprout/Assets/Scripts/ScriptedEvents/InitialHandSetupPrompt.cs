/*
	Connor McGwire - May 2016
	Controls display of starting controls reference
 */

using UnityEngine;
using System.Collections;

public class InitialHandSetupPrompt : MonoBehaviour {

	public float timeUntilFadeOut = 5f;

	private float fadeRate = 0.02f;
	private SpriteRenderer sRender;
	private bool visible = true;
	private Color originalColor, fullAlpha;

	// Use this for initialization
	void Start () {
		sRender = GetComponent<SpriteRenderer>();
		originalColor = sRender.color;
		fullAlpha = sRender.color;
		fullAlpha.a = 0;

		sRender.color = fullAlpha;
		Invoke("Disable", timeUntilFadeOut);
	}

	void Disable () {
		visible = false;
	}

	// Update is called once per frame
	void Update () {
		if (visible) {
			FadeIn();
		}
		else {
			FadeOut();
		}
	}

	void FadeIn() {
		if (sRender.color.a < 0.99f) {
			sRender.color = Color.Lerp(sRender.color, originalColor, fadeRate);
		}
		else if (sRender.color.a < 1) {
			sRender.color = originalColor;
		}
	}

	void FadeOut() {
		if (sRender.color.a > 0.01f) {
			sRender.color = Color.Lerp(sRender.color, fullAlpha, fadeRate);
		}
		else {
			Destroy(gameObject);
		}
	}
}
