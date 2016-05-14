using UnityEngine;
using System.Collections;

public class earthSwitch : MonoBehaviour {

    public earthPlatform[] platforms;

    void Start()
    {

    }
    // Update is called once per frame
    void Update () {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("earthSwitch Collide with " + other.gameObject.name);
        foreach(earthPlatform platform in platforms)
        {
            platform.switchPressed = true;
        }
    }
    
}
