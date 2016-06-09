using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindControl : MonoBehaviour {
    
    public float windPower = 5;

    void OnTriggerStay2D(Collider2D other)
    {
        var force = transform.right * windPower * Time.deltaTime;
        other.attachedRigidbody.AddForce(force);
    }
}
