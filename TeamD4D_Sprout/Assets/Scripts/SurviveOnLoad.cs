using UnityEngine;
using System.Collections;

public class SurviveOnLoad : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
