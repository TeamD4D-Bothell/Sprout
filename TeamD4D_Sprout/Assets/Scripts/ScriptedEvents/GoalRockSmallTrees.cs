/*
	Connor McGwire - June 2016
	Hooks carving graphics into the region vitality system
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class GoalRockSmallTrees : MonoBehaviour {

	public string regionName;
	private RegionVitalityManager region;

	[ColorUsage(true)]
	public Color livingColor;
	private Color originalColor;

	public float changeTime = .03f;
	public bool living = false;

	private SpriteRenderer sRender;

	private int changeStep = 2;

	// Use this for initialization
	void Start() {
		sRender = GetComponent<SpriteRenderer>();

		region = GameObject.Find(regionName).GetComponent<RegionVitalityManager>();

		if (!region) {
			Debug.LogError(name + " does not have a planting spot associated");
		}
	}

	void Update() {
		if (region.Living && (sRender.color != livingColor)) {
			sRender.color = Color.Lerp(sRender.color, livingColor, changeTime);
		}
		else if (region.Living && (sRender.color == livingColor)) {
			this.enabled = false;
		}
	}
}
