using UnityEngine;
using System;
using System.Collections;

public class PuzzleUI : CanvasUI {

	public Action OnResetPuzzle
	{
		get;
		set;
	}

	public Action OnGameOverPuzzle
	{
		get;
		set;
	}

	protected bool isActive = false;

	public void Active(){
		isTurnOn = true;
		if(OnResetPuzzle != null)
			OnResetPuzzle();
	}

	protected void Reset(){
		if(OnResetPuzzle != null)
			OnResetPuzzle();
	}

	protected void Finish(){
		isTurnOn = true;
		UnLockPlayerMove ();
		RunAnimations ();
	}

	private void UnLockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

	private void RunAnimations(){
		Debug.LogWarning ("ToDo: Run animations");
	}
}
