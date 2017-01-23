using UnityEngine;
using System.Collections;

public class ActiveUIPuzzle : InteractableObject {

    public HackDataGame dataGame;
    public Camera cameraPuzzle;
    protected PuzzleUI puzzle;
	private Camera mainCamera;

    void Awake() {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
        if (mainCamera == null)
            Debug.LogError("ActiveUIPuzzle requires a Camera in scene with name Main Camera");

        puzzle = GameObject.FindObjectOfType<PuzzleUI>();
        if (puzzle == null)
            Debug.LogError("ActiveUIPuzzle requires a GameObject in scene of type PuzzleUI");

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
