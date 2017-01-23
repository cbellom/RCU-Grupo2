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

    public Action OnCompletePuzzle
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

        RunAnimationsInPuzzle();

    }

	protected void Reset(){
		if(OnResetPuzzle != null)
			OnResetPuzzle(data);
	}

	protected void Finish(){
		isTurnOn = false;
        OnCompletePuzzle();
		UnLockPlayerMove ();
        RunAnimationsOutPuzzle();
	}

    protected void FinishOnFaild()
    {
        isTurnOn = false;
        UnLockPlayerMove();
        RunAnimationsOutPuzzle();
    }

    protected void UnLockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

	private void RunAnimationsInPuzzle()  {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetBool("isInPuzzle", true);
        GameObject playerEye = GameObject.FindGameObjectWithTag("PlayerEye");
        playerEye.GetComponent<Animator>().SetBool("isLoading", true);
    }

    private void RunAnimationsOutPuzzle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetBool("isInPuzzle", false);
        GameObject playerEye = GameObject.FindGameObjectWithTag("PlayerEye");
        playerEye.GetComponent<Animator>().SetBool("isLoading", false);
    }
}
