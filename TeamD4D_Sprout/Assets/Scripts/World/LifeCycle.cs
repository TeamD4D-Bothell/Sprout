using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeCycle : MonoBehaviour {

	//public bool spriteBased = false;

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	//public Sprite deadSprite;
	//public Sprite aliveSprite;

	public float changeTime = .03f;
	public bool living = false;

	private SpriteRenderer sRender;
	private Image image;

	//private SpriteRenderer otherRender;
	private int changeStep = 2;

	//private GameObject liveObject;

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

		//if (spriteBased) {
		//	sRender.sprite = deadSprite;
		//	CreateLiveSprite();
		//}
		//else {
		//	originalColor = sRender.color;
		//}
	}

	//void CreateLiveSprite() {
	//	liveObject = new GameObject(name + "_aliveSprite");
	//	liveObject.transform.parent = transform;
	//	liveObject.transform.localPosition = Vector3.zero;
	//	liveObject.AddComponent<SpriteRenderer>();

	//	otherRender = liveObject.GetComponent<SpriteRenderer>();
	//	otherRender.sprite = aliveSprite;
	//	otherRender.color = new Color(255, 255, 255, 0);
	//}

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
		//if (spriteBased) {
		//	SpriteChange();
		//}
		//else {
		//	ColorChange();
		//}
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

	//void SpriteChange() {
	//	if (!living) {
	//		if (sRender.color.a < 255 && otherRender.color.a > 0) {
	//			sRender.color = sRender.color + new Color(0, 0, 0, changeStep * Time.deltaTime * changeTime);
	//			otherRender.color = otherRender.color - new Color(0, 0, 0, changeStep * Time.deltaTime * changeTime);
	//		}
	//	}
	//	else {
	//		if (otherRender.color.a < 255 && sRender.color.a > 0) {
	//			sRender.color = sRender.color - new Color(0, 0, 0, changeStep * Time.deltaTime * changeTime);
	//			otherRender.color = otherRender.color + new Color(0, 0, 0, changeStep * Time.deltaTime * changeTime);
	//		}
	//	}
	//}
}
