using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/ResourceManagement/Survive On Load")]
public class SurviveOnLoad : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
