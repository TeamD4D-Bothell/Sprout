using UnityEngine;
using System.Collections;

[AddComponentMenu("Sprout/Events/Story Text Trigger")]
public class StoryTrigger : MonoBehaviour {

	[Multiline]
	public string textToDisplay = "EMPTY";
	public float displayTime = 1;

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log("TEXT SHOULD DISPLAY NOW");
		var storyText = GameObject.FindGameObjectWithTag("StoryPrompt").GetComponent<StoryText>();

		if (storyText) {
			storyText.TellStory(textToDisplay, displayTime);
			gameObject.SetActive(false);
		}
		else {
			Debug.LogError("StoryTrigger could not find reference to display text");
		}
	}
}
