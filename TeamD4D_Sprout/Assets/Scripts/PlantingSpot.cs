using UnityEngine;
using System.Collections;

public class PlantingSpot : MonoBehaviour {

    public GameObject plant;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Seed")
        {
            GameObject.Destroy(other.gameObject);
            GameObject obj = (GameObject)Instantiate(plant);
            obj.transform.position = transform.position;
        }
    }
}
