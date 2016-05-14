using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindControl : MonoBehaviour {

    private List<GameObject> myList;
    public float windPower = 5;

    private ParticleSystem myParticles;
	// Use this for initialization
	void Start ()
    {
        myList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //remove any null items from the list
        myList.RemoveAll(obj => obj == null);
        // update all the objects in the list
        foreach (GameObject g in myList)
        {
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * windPower);
        }
	}

    //Methods to add and remove items from the windControll's list
    void OnTriggerEnter2D(Collider2D other)
    {
        myList.Add(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (myList.Contains(other.gameObject))
        {
            myList.Remove(other.gameObject);
        }
    }
    //Several methods to change perameters of the wind on spawn
    void SetDirection(Vector2 direction)
    {
        this.transform.right = direction;
    }
    void SetDimension(float scale)
    {
        
    }
    void SetDuration(float dur)
    { }
}
