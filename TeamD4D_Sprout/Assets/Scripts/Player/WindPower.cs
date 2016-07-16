using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Sprout/AbilityScripts/Wind Power")]
public class WindPower : MonoBehaviour {
    
    public float windPower = 5;

    void OnTriggerStay2D(Collider2D other)
    {
        var force = transform.right * windPower * Time.deltaTime;
        other.attachedRigidbody.AddForce(force);
    }
}
