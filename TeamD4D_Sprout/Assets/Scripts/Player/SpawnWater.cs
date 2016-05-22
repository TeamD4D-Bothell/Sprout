using UnityEngine;
using System.Collections;

public class SpawnWater : MonoBehaviour {

    //this controlls how long after using the water power the player must wait to use it again
    public float interval = 3;
    public float veritcalOffset = .5f;
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
        if (Input.GetButtonDown("WaterPower") && Time.time - timer > interval)
        {
            //update timer
            timer = Time.time;
            //spawn water blast
            GameObject obj = (GameObject)Instantiate(myWaterBlast);
            obj.transform.position = new Vector3(this.transform.position.x, 
                this.transform.position.y + veritcalOffset, 0f);

            Rigidbody2D objRB = obj.GetComponent<Rigidbody2D>() as Rigidbody2D;
            Rigidbody2D playerRB = GetComponent<Rigidbody2D>() as Rigidbody2D;
            objRB.velocity = playerRB.velocity;
        }
	}
}
