using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[AddComponentMenu("Sprout/UI/Story Text")]
[RequireComponent(typeof(Text))]
public class StoryText : MonoBehaviour {

	private Text displayText;
	private float timer = 0;

	public float fadeInTime = 3;
	public float fadeOutTime = 3;
	private float displayTime = 1;

	private enum displayState {
		standby,
		fadingIn,
		displaying,
		fadingOut
	}

	private displayState currState = displayState.standby;
	private Color originalColor;
	private Color transparentColor;
	
	/******************************************************************/

	void Start () {
		displayText = GetComponent<Text>();
		displayText.text = "COMPONENT FOUND";
		originalColor = displayText.color;

		transparentColor = originalColor;
		transparentColor.a = 0;

		displayText.color = transparentColor;
	}

	// Update is called once per frame
	void Update () {
		switch (currState) {
			case displayState.standby:
				break;
			case displayState.fadingIn:
				fadeIn();
				break;
			case displayState.displaying:
				display();
				break;
			case displayState.fadingOut:
				fadeOut();
				break;
			default:
				break;
		}
	}

	public void TellStory(string newText, float time) {
		displayText.text = newText;
		displayTime = time;
		timer = fadeInTime;
		currState = displayState.fadingIn;
	}

	/*************************************************************/

	private void fadeIn() {
		timer -= Time.deltaTime;

		var updateColor = displayText.color;
		updateColor.a += (1 / fadeInTime) * Time.deltaTime;
		displayText.color = updateColor;

		if (timer <= 0) {
			displayText.color = originalColor;
			timer = displayTime;
			currState = displayState.displaying;
		}
	}

	private void display() {
		timer -= Time.deltaTime;
		
		if (timer <= 0) {
			timer = fadeOutTime;
			currState = displayState.fadingOut;
		}
	}

	private void fadeOut() {
		timer -= Time.deltaTime;

		var updateColor = displayText.color;
		updateColor.a -= (1 / fadeInTime) * Time.deltaTime;
		displayText.color = updateColor;

		if (timer <= 0) {
			displayText.color = transparentColor;
			currState = displayState.standby;
		}
	}
}
