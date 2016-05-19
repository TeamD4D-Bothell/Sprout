using UnityEngine;
using System.Collections;

public class GoldenEffect : MonoBehaviour {
	
	void Start () {
		var prefab = Resources.Load("Prefabs/GoldenEffect");

		if (prefab != null) {
			var goldenEffect = Instantiate(prefab) as GameObject;
			goldenEffect.transform.position = transform.position;
			goldenEffect.transform.SetParent(transform, true);
		}
		else {
			Debug.LogError("Golden Effect prefab not found");
		}
	}
}
