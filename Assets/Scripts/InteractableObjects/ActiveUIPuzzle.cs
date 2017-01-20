using UnityEngine;
using System.Collections;

public class ActiveUIPuzzle : InteractableObject {
	
	public UIPuzzle puzzle;
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
		Debug.Log ("Hola");
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
