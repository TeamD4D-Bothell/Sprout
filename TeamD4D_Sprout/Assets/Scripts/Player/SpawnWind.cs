using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnWind : MonoBehaviour {

    public int maxNumber = 1;
    private GameObject myWind;
    private List<GameObject> objects; 
    private bool full = false;


    void Start()
    {
        if (myWind == null)
        {
            this.myWind = Resources.Load("Prefabs/WindZone") as GameObject;
        }
        objects = new List<GameObject>();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!full)
            {
                GameObject obj = (GameObject)Instantiate(myWind);
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Vector3 positionDiference = mousePos - this.transform.position;
                Vector2 mouseDir = Vector3.Normalize(positionDiference);


                obj.transform.right = mouseDir;
                obj.transform.position = this.transform.position;
                objects.Add(obj);

                full = (objects.Count >= maxNumber);
            }
            else
            {
                for (int i = objects.Count - 1; i >= 0; i--)
                {
                    Destroy(objects[i]);
                    objects.RemoveAt(i);
                }
                full = false;

            } 
		}
	}
}
