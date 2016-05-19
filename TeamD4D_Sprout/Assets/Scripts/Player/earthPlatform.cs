using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class earthPlatform : MonoBehaviour
{
    float timer;
    Vector3 startMarker;
    Vector3 endMarker;
    public float distance;
    public float speed = 1f;
    private float startTime;
    private float journeyLength;
    float resetTimer;
    bool isMoving = false;
    float mSpeed = 5f;
    public bool switchPressed;
    bool isUp;
    public bool vertical;
    // Use this for initialization
    void Start()
    {
        isUp = false;
        timer = 3f;
        resetTimer = 3f;
        startMarker = transform.position;
        
        if (!vertical) vertical = false;
        if (vertical) endMarker = new Vector3(transform.position.x, transform.position.y + distance);
        else endMarker = new Vector3(transform.position.x + distance, transform.position.y);
        journeyLength = Vector3.Distance(transform.position, endMarker);
        switchPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isMoving == false) && Input.GetKeyUp(KeyCode.E) && switchPressed)
        {
            // earthPlatform = 
            Debug.Log("EARTH!");
            isMoving = true;
            startTime = Time.time;
        }
        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            if (!isUp)
            {
                transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
            }
            else transform.position = Vector3.Lerp(endMarker, startMarker, fracJourney);

            timer -= Time.deltaTime;
           
           if(fracJourney > .9999)
            {
                isMoving = false;
                switchPressed = false;
                if (isUp) isUp = false;
                else isUp = true;
            }
        }
    }
}