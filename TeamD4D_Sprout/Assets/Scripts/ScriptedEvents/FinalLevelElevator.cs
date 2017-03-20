/*
	Connor McGwire - June 2016
	Component for moving the elevator at the end of the game
 */

using UnityEngine;
using System.Collections;

public class FinalLevelElevator : MonoBehaviour {

	public string regionName;
	private RegionVitalityManager region;

	public Vector3 start;
	public Vector3 end;

	public float moveRate = 1f;

	// Use this for initialization
	void Start () {
		region = GameObject.Find(regionName).GetComponent<RegionVitalityManager>();

		transform.localPosition = start;

		if (!region) {
			Debug.LogError(name + " does not have a planting spot associated");
		}
	}

	// Update is called once per frame
	void Update () {
		if(region.Living) {
			var scaledRate = Time.deltaTime * moveRate;
			transform.localPosition = Vector3.Lerp(transform.localPosition, end, scaledRate);
		}
	}
}
