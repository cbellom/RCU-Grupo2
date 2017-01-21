using UnityEngine;
using System.Collections;

public class ActiveUIPuzzle : InteractableObject {

    public HackDataGame dataGame;
    public PuzzleUI puzzle;
	public Camera cameraPuzzle;
	private Camera mainCamera;

    void Awake() {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		ObjectActivated += HandleExampleObjectActived;
		ObjectFinished += HandleExampleObjectExpired;
	}

	private void HandleExampleObjectActived() {
		ActivePuzzle ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleExampleObjectExpired(GameObject player) {
		Destroy(gameObject);
	}

	private void ActivePuzzle() {
		LockPlayerMove ();
		SwitchCameras ();
		puzzle.Active(dataGame);
	}

	private void SwitchCameras(){
		SceneCamerasController camerasController = GameObject.FindObjectOfType<SceneCamerasController> ();
		camerasController.ActiveCameraByName (cameraPuzzle.name);
	}

	private void LockPlayerMove(){
		player.GetComponent<CharacterMoveController> ().enabled = false;
	}
}
