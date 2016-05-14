using UnityEngine;
using System.Collections;

public class SeedScript : MonoBehaviour {

    public PlantType type = PlantType.Tree;
    public bool golden = false;

	void Start() {
		if (golden) {
			var prefab = Resources.Load("Prefabs/GoldenEffect");
			var goldenEffect = Instantiate(prefab) as GameObject;
			goldenEffect.transform.position = transform.position;
			goldenEffect.transform.SetParent(transform, true);
		}
	}
}
