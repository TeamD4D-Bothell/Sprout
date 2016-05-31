using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class earthSwitch : MonoBehaviour {

    public earthPlatform[] platforms;

	private bool pressed = false;
	private SpriteRenderer sRender;
	private Sprite unpressedSprite;
	public Sprite pressedSprite;

    public AudioClip earthSound;

    private bool playerPresent = false;

    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
		unpressedSprite = sRender.sprite;
    }

	void Update() 
	{
        
        if(areMoving() && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().PlayOneShot(earthSound);
        if (!areMoving() && GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Stop();

        if (playerPresent && Input.GetButtonDown("Use")) 
		{
          
            
            if (allPlatformsUpOrAllPlatformsDown()) 
			{
				if (!areMoving()) 
				{
                    GetComponent<AudioSource>().Stop();
                    SwitchSprite();
				}
                
                foreach (earthPlatform platform in platforms) 
				{
					platform.switchPressed = true;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		playerPresent = true;
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		playerPresent = false;
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

	bool areMoving() 
	{
		foreach (earthPlatform platform in platforms) 
		{
			if (platform.isMoving) 
			{
				return true;
			}
		}
        return false;
	}

	public void SwitchSprite() 
	{
		pressed = !pressed;

		if (pressed) 
		{
			sRender.sprite = pressedSprite;
		}
		else 
		{
			sRender.sprite = unpressedSprite;
		}
	}
}
