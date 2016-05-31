using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnWind : MonoBehaviour {

    public int maxNumber = 1;
    public float duration = 5;

    private AudioClip windSound;
    //this struct will keep track of a windZone and it's associated timer
    private struct WindItem
    {
        public GameObject windZone;
        public float timer;
    }
    private GameObject myWind;
    private List<WindItem> objects; 


    void Start()
    {
        if (myWind == null)
        {
            this.myWind = Resources.Load("Prefabs/WindZone") as GameObject;
        }
        if (windSound == null)
        {
            this.windSound = Resources.Load("Audio/Whoosh") as AudioClip;
        }
        objects = new List<WindItem>();
    }

	// Update is called once per frame
	void Update () {

        //check for mouse input
        if (Input.GetButtonDown("WindPower"))
        {
            //check if the list already contains the max number of windZones
            if (objects.Count >= maxNumber)
            {
                for (int w = objects.Count - 1; w >= 0; w--)
                {
                    Destroy(objects[w].windZone);
                    objects.RemoveAt(w);
                }
            }
            if(objects.Count < maxNumber)
            {
                //play audio
                AudioSource.PlayClipAtPoint(windSound, this.transform.position, 1f);
                //create a new wind zone and set direction to mouse location
                GameObject obj = (GameObject)Instantiate(myWind);
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Vector3 positionDiference = mousePos - this.transform.position;
                Vector2 mouseDir = Vector3.Normalize(positionDiference);

                obj.transform.right = mouseDir;
                obj.transform.position = this.transform.position;

                //add new windzone to a struct
                WindItem temp = new WindItem();
                temp.timer = Time.time;
                temp.windZone = obj;
                //add struct to the list
                objects.Add(temp);
            }
		}

        // check timers of all objects in the list
        int i = 0;
        while (i < objects.Count)
        {
            //if timer has expired delete and remove item
            if (Time.time - duration >= objects[i].timer)
            {
                Destroy(objects[i].windZone);
                objects.RemoveAt(i);
            }
            //otherwise move to the next item in the list
            else
            {
                i++;
            }
        }
	}
}
