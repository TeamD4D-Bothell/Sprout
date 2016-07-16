using UnityEngine;
using System.Collections;
/// <summary>
/// Searches for a RegionVitalityManager by name of the attached
/// GameObject then adds a color change function to that region's
/// onRegionRevive event
/// </summary>
[AddComponentMenu("Sprout/Events/Triggered Color Change")]
[RequireComponent(typeof(SpriteRenderer))]
public class TriggeredColorChange : MonoBehaviour {

	public string regionName;
	private RegionVitalityManager region;

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	public float changeTime = 3f;
	public bool living = false;

	private SpriteRenderer sRender;

	// Use this for initialization
	void Start() {
		sRender = GetComponent<SpriteRenderer>();

		region = GameObject.Find(regionName).GetComponent<RegionVitalityManager>();
		if (region) {
			region.onRegionRevive.AddListener(TriggerColorChange);
		}
		else { 
			Debug.LogError(name + " does not have a planting spot associated");
		}
	}

	// Wrapper for color change
	public void TriggerColorChange() {
		if (!living) {
			StartCoroutine("ColorChange");
			living = true;
		}
	}

	// Color change taken from LifeCycle
	IEnumerator ColorChange() {
		for (float t = 0; t < changeTime; t += Time.deltaTime) {
			sRender.color = Color.Lerp(originalColor, livingColor, t / changeTime);
			yield return null;
		}
		sRender.color = livingColor;
	}
}
