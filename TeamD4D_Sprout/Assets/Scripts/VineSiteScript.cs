using UnityEngine;
using System.Collections;

public class VineSiteScript : MonoBehaviour {

    private bool grow = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "VineSeed")
        {
            other.transform.position = this.transform.position;
            grow = true;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }
    }
}
