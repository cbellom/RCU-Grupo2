using UnityEngine;
using System;
using System.Collections;

public class PuzzleUI : CanvasUI {
    private DataPuzzle data;

	public Action<DataPuzzle> OnResetPuzzle
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

	public void Active(DataPuzzle data)
    {
        this.data = data;
		isTurnOn = true;
		if(OnResetPuzzle != null)
			OnResetPuzzle(data);
	}

	protected void Reset(){
		if(OnResetPuzzle != null)
			OnResetPuzzle(data);
	}

	protected void Finish(){
		isTurnOn = false;
		UnLockPlayerMove ();
		RunAnimations ();
	}

	protected void UnLockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

	private void RunAnimations(){
		Debug.LogWarning ("ToDo: Run animations");
	}
}
