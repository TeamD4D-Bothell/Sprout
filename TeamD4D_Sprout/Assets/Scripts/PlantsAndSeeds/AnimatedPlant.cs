using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/PlantScripts/Animated Plant")]
public class AnimatedPlant : MonoBehaviour {

	// Can be left null if no plant is to be grown
	public GameObject seedToGrow;
	public Vector3 offset = new Vector3(0, 0, 0);

	// This function is called by the animation event
	public void Grow() {
		// Check if there is any seed to grow then instantiate it
		if (seedToGrow) {
			var seed = Instantiate(seedToGrow) as GameObject;
			seed.transform.position = transform.position;
			seed.transform.position += offset;
		}

		// Tell the parent or attached PlantScript that
		// the animation has reached the trigger point
		var plantScript = GetComponentInParent<PlantScript>();
		if (plantScript) {
            // Animation controls timing, thus called here
			plantScript.SignalGrown();
		}
	}
}
