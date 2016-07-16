using UnityEngine;
using System.Collections;
using System;
using System.Threading;

[AddComponentMenu("Sprout/AbilityScripts/Earth Platform")]
public class earthPlatform : MonoBehaviour
{

    Vector3 startMarker;
    Vector3 endMarker;
    public float distance;
    public float speed = 1f;
    private float startTime;
    private float journeyLength;
    public bool isMoving;
    public bool switchPressed;
    public bool isUp;
    public bool vertical;
    // Use this for initialization
    void Start()
    {
        isMoving = false;
        isUp = false;
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
        if ((isMoving == false) && switchPressed)
        {
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