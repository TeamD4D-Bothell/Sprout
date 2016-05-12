using UnityEngine;
using System.Collections;

public enum PlantType {
	Tree,
	Vine
}

public class PlantingSpot : MonoBehaviour {

	//public GameObject plant;
	public bool Golden = false;
    public PlantType type = PlantType.Tree;
	public bool plantedAtStart = false;

    private bool occupied = false;
    private GameObject myPlant;
    private GameObject mySprout;
    //This will store a reference the specific instance of whatever sprout is spawned
    //this will allow the sprout to be destroyed later after watering
    private GameObject mySproutClone;
    //this bool will indicate if a fully grown plant is already in place
    private bool hasSprout = false;

    // Use this for initialization
    void Start()
    {
        //this will load the recoursces needed later on initialise, so that 
        //performance will not be effected while playing.
        if (type == PlantType.Tree)
        {
            if (myPlant == null)
            {
                Debug.Log("loading tree");
                myPlant = Resources.Load("Prefabs/Tree") as GameObject;
            }
            if (mySprout == null)
            {
                mySprout = Resources.Load("Prefabs/TreeSprout") as GameObject;
            }
        }
        else if (type == PlantType.Vine)
        {
            if (myPlant == null)
            {
                myPlant = Resources.Load("Prefabs/Vine") as GameObject;
            }
        }

		if (plantedAtStart) {
			switch (type) {
				case PlantType.Tree:
					PlantATreeSprout();
					break;
				case PlantType.Vine:
					break;
				default:
					break;
			}
		}
    }
    //check for collision with seeds
    void OnTriggerEnter2D(Collider2D other)
    {
        //check if other object is a seed and if this planting spot is unoccupied
        if (other.tag == "Seed" && !occupied) {
			//Debug.Log("seed collision");
			//other object is indeed a seed, so get the seed script
			SeedScript seedScript = other.GetComponent<SeedScript>();

			//check the type of seed, make sure it corrisponds to this.type,
			// if so instansiate the corrisponding plant type.

			//TODO add functionality to detect if seed/ planting site is golden

			if (Golden == seedScript.Golden) {
				switch (type) {
					case PlantType.Tree:
						if (seedScript.type == PlantType.Tree) {
							PlantATreeSprout();
						}
						break;
					case PlantType.Vine:
						if (seedScript.type == PlantType.Vine) {
							PlantAVine();
						}
						break;
					default:
						break;
				}
				GameObject.Destroy(other.gameObject);
			}
        }
    }
    //check for collision with water particles
    void OnParticleCollision(GameObject other)
    {
        //check for conditions that show that a sprout has been planted, but has not grown yet
        if (hasSprout  && other.tag == "Water")
        {
            hasSprout = false;
            Destroy(mySproutClone);
            PlantATree();
        }
    }

    //private helper function to create a sprout
    private void PlantATreeSprout()
    {
        if (mySprout != null)
        {
            GameObject obj = (GameObject)Instantiate(mySprout);
            obj.transform.position = transform.position;

            //set occupied to true so that multiple seeds cannot plant in the same spot.
            occupied = true;
            // save a reference to the sprout so it can be deleted later
            mySproutClone = obj;
            hasSprout = true;
        }
        else
        {
            Debug.Log("TreeSprout prefab was null");
        }
    }

    //private helper function to plant a tree
    private void PlantATree()
    {
        if (myPlant != null)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load("Prefabs/Tree"));
            obj.transform.position = transform.position;

            //set occupied to true so that multiple seeds cannot plant in the same spot.
            //may be redundant if sprout was planted first
            occupied = true;
        }
        else
        {
            Debug.Log("Tree prefab was null");
        }
    }
    private void PlantAVine()
    {
        if (myPlant != null)
        {
            GameObject obj = (GameObject)Instantiate(myPlant);
            obj.transform.position = transform.position;

            //set occupied to true so that multiple seeds cannot plant in the same spot.
            occupied = true;
        }
        else
        {
            Debug.Log("Vine prefab was null");
        }
    }

}
