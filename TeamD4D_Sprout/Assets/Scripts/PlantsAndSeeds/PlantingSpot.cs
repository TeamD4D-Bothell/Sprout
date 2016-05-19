using UnityEngine;
using System.Collections;

public enum PlantType {
	Tree,
	Vine
}

public class PlantingSpot : MonoBehaviour {

	//public GameObject plant;
	public bool golden = false;
    public PlantType type = PlantType.Tree;
	public bool plantedAtStart = false;
	public GameObject plantPrefab;

    private bool occupied = false;

    // Use this for initialization
    void Start()
    {
		if (plantedAtStart && plantPrefab != null) 
		{
			Invoke("GrowPlant", 0.1f);
		}
    }

    //check for collision with seeds
    void OnTriggerEnter2D(Collider2D other)
    {
        //check if other object is a seed and if this planting spot is unoccupied
        if (other.tag == "Seed" && !occupied)
		{
			//Debug.Log("seed collision");
			//other object is indeed a seed, so get the seed script
			SeedScript seedScript = other.GetComponent<SeedScript>();

			// check the type of seed, make sure it corrisponds to this.type,
			// if so instansiate the corrisponding plant type.
			if (seedScript.type == type
				&& golden == seedScript.golden) 
			{
				GrowPlant();
				GameObject.Destroy(other.gameObject);
			}
		}
    }

    //private helper function to create a sprout
    private void GrowPlant()
    {
        if (plantPrefab != null)
        {
			var plant = Instantiate(plantPrefab) as GameObject;
			plant.transform.position = transform.position;
			plant.transform.SetParent(transform.parent, true);

			gameObject.SetActive(false);
		}
        else
        {
            Debug.Log("Prefab was null");
        }
    }
}
