using UnityEngine;
using System.Collections;

public class ActiveUIPuzzle : InteractableObject {
	
	public PuzzleUI puzzle;
	public Camera cameraPuzzle;
	private Camera mainCamera;

	void Awake() {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		ObjectActivated += HandleExampleObjectActived;
		ObjectFinished += HandleExampleObjectExpired;
	}

	private void HandleExampleObjectActived() {
		ActivePuzze ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleExampleObjectExpired(GameObject player) {
		Destroy(gameObject);
	}

	private void ActivePuzze() {
		LockPlayerMove ();
		SwitchCameras ();
		puzzle.Active();
	}

	private void SwitchCameras(){
		mainCamera.enabled = false;
		cameraPuzzle.enabled = true;
	}

	private void LockPlayerMove(){
		player.GetComponent<CharacterMoveController> ().enabled = false;
	}
}
