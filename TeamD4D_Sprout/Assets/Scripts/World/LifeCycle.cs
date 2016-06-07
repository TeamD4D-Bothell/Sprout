using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeCycle : MonoBehaviour {

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	public float changeTime = 3f;
	public bool living = false;

	private float scaledChangeTime;

	private SpriteRenderer sRender;
	private Image image;

	// Use this for initialization
	void Start () {
		changeTime += 1f;
		sRender = GetComponent<SpriteRenderer>();
		if (sRender == null) {
			image = GetComponent<Image>();
			originalColor = image.color;
		}
		else {
			originalColor = sRender.color;
		}
	}

	void Update() {
		scaledChangeTime = changeTime * Time.deltaTime;

		if (sRender != null) {
			ColorChange();
		}
		else if (image != null) {
			ColorChangeImage();
		}
		else {
			Debug.Log("No image or sprite renderer on " + name);
		}
	}

	void ColorChange() {
		if (living && (sRender.color != livingColor)) {
			sRender.color = Color.Lerp(sRender.color, livingColor, scaledChangeTime);
		}
		else if (sRender.color != originalColor){
			sRender.color = Color.Lerp(sRender.color, originalColor, scaledChangeTime);
		}
	}

	void ColorChangeImage() {
		if (living && (image.color != livingColor)) {
			image.color = Color.Lerp(image.color, livingColor, scaledChangeTime);
		}
		else if (image.color != originalColor) {
			image.color = Color.Lerp(image.color, originalColor, scaledChangeTime);
		}
	}
}
