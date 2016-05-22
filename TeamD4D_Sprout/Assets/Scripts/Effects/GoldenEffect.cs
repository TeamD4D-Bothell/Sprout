using UnityEngine;
using System.Collections;

public class GoldenEffect : MonoBehaviour {

	public GameObject effect;

	void Start () {
		if (effect) {
			var effectObject = Instantiate(effect) as GameObject;
			effectObject.transform.position = transform.position;
			effectObject.transform.SetParent(transform, true);
		}
		else {
			Debug.Log("Golden Effect prefab not found");
		}
	}
}
