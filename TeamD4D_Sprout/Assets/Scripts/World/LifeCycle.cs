using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeCycle : MonoBehaviour {

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	public float changeTime = .03f;
	public bool living = false;

	private SpriteRenderer sRender;
	private Image image;
	
	private int changeStep = 2;

	// Use this for initialization
	void Start () {
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
			sRender.color = Color.Lerp(sRender.color, livingColor, changeTime);
		}
		else if (sRender.color != originalColor){
			sRender.color = Color.Lerp(sRender.color, originalColor, changeTime);
		}
	}

	void ColorChangeImage() {
		if (living && (image.color != livingColor)) {
			image.color = Color.Lerp(image.color, livingColor, changeTime);
		}
		else if (image.color != originalColor) {
			image.color = Color.Lerp(image.color, originalColor, changeTime);
		}
	}
}
