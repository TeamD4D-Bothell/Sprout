using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class earthPlatform : MonoBehaviour
{
   public float timer = .4f;
    float resetTimer;
    bool isMoving = false;
    float mSpeed = 5f;
    public bool switchPressed;
    public bool isUp;
    public bool vertical;
    // Use this for initialization
    void Start()
    {
        resetTimer = timer;
        switchPressed = false;
       if(!isUp) isUp = false;
        if (!vertical) vertical = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if ((isMoving == false) && Input.GetKeyUp(KeyCode.E) && switchPressed)
        {
                // earthPlatform = 
                Debug.Log("EARTH!");
                isMoving = true;
        }
        if(isMoving == true)
        {
            timer -= Time.deltaTime;
            if(timer > 0)
            {
                if (vertical)
                {
                    if (isUp == false) transform.position += (mSpeed * Time.smoothDeltaTime) * transform.up;
                    if (isUp == true) transform.position -= (mSpeed * Time.smoothDeltaTime) * transform.up;
                }
                else
                {
                    if (isUp == false) transform.position += (mSpeed * Time.smoothDeltaTime) * transform.right;
                    if (isUp == true) transform.position -= (mSpeed * Time.smoothDeltaTime) * transform.right;
                }
            }
            else
            {
                isMoving = false;
                if (isUp == false) isUp = true;
                else if (isUp == true) isUp = false;
                timer = resetTimer;
                switchPressed = false;
            }
        }
    }
}