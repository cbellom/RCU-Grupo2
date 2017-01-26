using UnityEngine;
using System.Collections;

public class ActiveUIPuzzle : InteractableObject {

    public HackDataGame dataGame;
	public Camera cameraPuzzle;
	[Header("Cinematic") ]
	public int cinematicNumber;
	public float cinematicTime;
	public CinematicsController cinematics;
    protected PuzzleUI puzzle;
	private Camera mainCamera;
    
    void Awake() {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
        if (mainCamera == null)
            Debug.LogError("ActiveUIPuzzle requires a Camera in scene with name Main Camera");

        puzzle = GameObject.FindObjectOfType<PuzzleUI>();
        if (puzzle == null)
            Debug.LogError("ActiveUIPuzzle requires a GameObject in scene of type PuzzleUI");

        ObjectActivated += HandleObjectActived;
	}

	private void HandleObjectActived() {
		ActivePuzzle ();
    }

	private void DestroyTrigger() {
		LockPlayerMove ();
		Play ();
		StopAllCoroutines ();
		StartCoroutine(WaitToStopCinematic(cinematicTime));
	}

    private void ResetTriggerCollider()
    {
		gameObject.GetComponent<Collider>().enabled = true;
		gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void ActivePuzzle() {
        LockPlayerMove ();
		SwitchCameras ();
		puzzle.OnGameOverPuzzle = null;
		puzzle.OnCompletePuzzle = null;
        puzzle.OnGameOverPuzzle += ResetTriggerCollider;
        puzzle.OnCompletePuzzle += DestroyTrigger;
        puzzle.Active(dataGame);
	}

    private void DisableTriggerCollider() {
		gameObject.GetComponent<Collider>().enabled = false;
		gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

	private void SwitchCameras(){
		SceneCamerasController.ActiveCameraByName (cameraPuzzle.name);
	}
	private void Stop (){
		SceneCamerasController.ActiveCameraByName ("Main Camera");
		cinematics.gameObject.SetActive (false);
		cinematics.StopCinematic ();		
	}

	private void Play() {
		SceneCamerasController.ActiveCameraByName (cinematics.camera.name);
		cinematics.gameObject.SetActive (true);
		cinematics.PlayCinematic (cinematicNumber);
	}

	private void LockPlayerMove(){
		player.GetComponent<CharacterMoveController> ().enabled = false;
	}

	protected void UnLockPlayerMove(){
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

	private IEnumerator WaitToStopCinematic(float time){
		yield return new WaitForSeconds (time);
		Stop ();
		UnLockPlayerMove ();
		Destroy (gameObject);

	}
}
