using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/AbilityScripts/Water Power")]
public class WaterPower : MonoBehaviour {
    private float timer;
    //this property dictates how long the particle spawner will persist after instansiation
    public float duration = 10;

	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.time - timer > duration)
        {
            Destroy(this.gameObject);
        }
	}
}
