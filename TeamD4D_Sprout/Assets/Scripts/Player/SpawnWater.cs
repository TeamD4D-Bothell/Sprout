using UnityEngine;
using System.Collections;

public class SpawnWater : MonoBehaviour {

    //this controlls how long after using the water power the player must wait to use it again
    public float interval = 3;
    private float timer;
    private GameObject myWaterBlast;

	// Use this for initialization
	void Start ()
    {
        if (myWaterBlast == null)
        {
            myWaterBlast = Resources.Load ("Prefabs/WaterBlast") as GameObject;
        }
        this.timer = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //detect user input and check time interval
        if (Input.GetMouseButtonDown(1) && Time.time - timer > interval)
        {
            //update timer
            timer = Time.time;
            //spawn water blast
            GameObject obj = (GameObject)Instantiate(myWaterBlast);
            obj.transform.position = this.transform.position;
            //TODO optionally add a rigidbody to the water blast prefab, so it can have velocity
            //then here set the velocity of the water blast to equal the players velocity for more
            //realistic looking effect.
        }
	}
}
