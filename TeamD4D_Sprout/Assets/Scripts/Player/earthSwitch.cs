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
        if (allPlatformsUpOrAllPlatformsDown()) {
            foreach (earthPlatform platform in platforms)
            {
                platform.switchPressed = true;
            }
        }
    }

    bool allPlatformsUpOrAllPlatformsDown()
    {
        if (allUp() || allDown()) return true;
        else return false;
    }

    bool allUp()
    {
        foreach (earthPlatform platform in platforms)
        {
            if (platform.isUp == true) continue;
            return false;
        }
        return true;
    }

    bool allDown()
    {
        foreach (earthPlatform platform in platforms)
        {
            if (platform.isUp == false) continue;
            return false;
        }
        return true;
    }
}
