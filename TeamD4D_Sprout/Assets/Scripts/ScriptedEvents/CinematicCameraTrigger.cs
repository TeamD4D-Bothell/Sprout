using UnityEngine;
using System.Collections;

public class CinematicCameraTrigger : MonoBehaviour {

	private enum CameraState {
		waiting,
		setup,
		triggered
	}

	private CameraState state = CameraState.waiting;
	private GameObject cinematicCamera;

	private GameObject mainCamera;
	private GameObject player;
	private PlayerMovement playerMovement;
	private CameraLogic mainCameraLogic;


	// Use this for initialization
	void Start () {
		cinematicCamera = GetComponentInChildren<Camera>(true).gameObject;
		cinematicCamera.SetActive(false);

		mainCamera = Camera.main.gameObject;
		mainCameraLogic = mainCamera.GetComponent<CameraLogic>();

		player = GameObject.FindGameObjectWithTag("Player");
		playerMovement = player.GetComponent<PlayerMovement>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(state == CameraState.waiting) {
			state = CameraState.setup;

			playerMovement.Disable();
			mainCameraLogic.enabled = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(state == CameraState.setup) {
			mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,
				cinematicCamera.transform.position, 0.6f * Time.deltaTime);

			var distance = Vector2.Distance(mainCamera.transform.position, 
				cinematicCamera.transform.position);

			if (distance < 0.1f) {
				mainCamera.SetActive(false);
				cinematicCamera.SetActive(true);
				state = CameraState.triggered;
			}
		}
	}

	public void Exit() {
		cinematicCamera.SetActive(false);
		mainCamera.SetActive(true);
		playerMovement.enabled = true;
	}
}
