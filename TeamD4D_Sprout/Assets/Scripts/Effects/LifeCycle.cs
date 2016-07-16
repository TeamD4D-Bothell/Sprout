using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Sprout/Effects/Life Cycle")]
public class LifeCycle : MonoBehaviour {

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	private float changeTime = 3f;
	private float changeSmoothness = 0.2f;
	private bool living = false;

	private float scaledChangeTime;

	private SpriteRenderer sRender;
	private Image image;

	private RegionVitalityManager region;

	// Use this for initialization
	void Start () {
		// Find the sprite renderer or image component that will be changed
		sRender = GetComponent<SpriteRenderer>();
		if (!sRender) {
			image = GetComponent<Image>();
			originalColor = image.color;
		}
		else {
			originalColor = sRender.color;
		}

		// If region hasn't been revived yet, add "setAlive" as a listener
		region = GetComponentInParent<RegionVitalityManager>();

		if (region && !region.Living) {
			region.onRegionRevive.AddListener(setAlive);
		}
		else if (region && region.Living) {
			// If the region is already alive, setAlive
			setAlive();
		}
	}

	// Starts coroutine to begin color change
	public void setAlive() {
		if (!living) {
			if (sRender) {
				StartCoroutine("ColorChange");
			}
			if (image != null) {
				StartCoroutine("ColorChangeImage");
			}
			living = true;
		}
		else {
			Debug.Log("Why is this being called?");
		}
	}
	
	// Lerps from current color to color selected as 'living'
	IEnumerator ColorChange() {
		for (float t = 0; t < changeTime; t += Time.deltaTime) {
			sRender.color = Color.Lerp(originalColor, livingColor, t / changeTime);
			yield return null;
		}
		sRender.color = livingColor;
	}

	IEnumerator ColorChangeImage() {
		for (float t = 0; t < changeTime; t += Time.deltaTime) {
			image.color = Color.Lerp(originalColor, livingColor, t / changeTime);
			yield return null;
		}
		image.color = livingColor;
	}
}
