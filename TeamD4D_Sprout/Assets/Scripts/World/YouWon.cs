using UnityEngine;
using System.Collections;

public class YouWon : MonoBehaviour {

	private RegionVitalityManager manager;
	private MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		manager = GetComponentInParent<RegionVitalityManager>();
		mesh = GetComponent<MeshRenderer>();
		if (mesh) {
			mesh.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (manager) {
			if (manager.Living && !mesh.enabled) {
				mesh.enabled = true;
			}
		}
	}
}
