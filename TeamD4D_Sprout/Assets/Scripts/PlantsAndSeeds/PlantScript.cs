using UnityEngine;
using System.Collections;

public class PlantScript : MonoBehaviour {

    //this float represents how long growing will take
    public float growthDelay = 5;
    private float timer;
    Collider2D myCollider;

	// Use this for initialization
	void Start ()
    {
        timer = Time.time;
        myCollider = gameObject.GetComponent<Collider2D>();
        if (myCollider != null)
        {
            myCollider.enabled = false;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        //TODO add any needed animation code here

        if (Time.time - timer > growthDelay)
        {
            if (myCollider != null)
            {
                myCollider.enabled = true;
            }
        }
	}
}
