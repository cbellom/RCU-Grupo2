using UnityEngine;
using System.Collections;

public class PlayCinematic : InteractableObject {
	public int cinematicNumber;
	public CinematicsController cinematics;

	void Awake() { 	
		ObjectActivated += HandleObjectActived;
		ObjectFinished += HandleObjectExpired;
	}

	private void HandleObjectActived() {
		LockPlayerMove ();
		Play ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleObjectExpired(GameObject player) {
		Stop ();
		UnLockPlayerMove ();
		Destroy (gameObject);
	}

	private void Stop (){
		SceneCamerasController.ActiveCameraByName ("Main Camera");
		cinematics.StopCinematic ();		
	}

	private void Play() {
		SceneCamerasController.ActiveCameraByName (cinematics.camera.name);
		cinematics.PlayCinematic (cinematicNumber);
	}

	protected void LockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = false;
	}

	protected void UnLockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

}
